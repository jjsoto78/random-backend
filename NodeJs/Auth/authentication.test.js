//The jest object is automatically in scope within every test file. Below import is not needed
// import {expect, jest, test} from '@jest/globals';
const request = require('supertest')
const { appWithDI } = require('./authentication')
// separate the endpoints from the server for superuser testing and TDD

// mock bcrypt functions
const genSalt = jest.fn()
const compare = jest.fn()
const hash = jest.fn()

//mock database functions
const getUsers = jest.fn()
const addUser = jest.fn()
// jest.useFakeTimers('legacy')

// database layer gets injected into the endpoint, with this we can mock the database, change database layer, etc, endpoint code is loosely coupled
// now app has a mocked database object for the remainde of the test
const app = appWithDI({getUsers, addUser}, {genSalt, compare, hash})

describe('POST /login', ()=>{
    describe('given users name and password', ()=>{
        test('response should contain the request user name', async()=>{
            // needs mocking of bcrypt
            const mockedUser = {name:'jcs1', password:'jcsPassword1'}
            getUsers.mockReturnValue([mockedUser])
            compare.mockReturnValue(true)

            const response = await request(app).post('/login').send(mockedUser)

            expect(response.body.name).toBe('jcs1')
        })
    
    })

})


describe('POST /user', ()=>{

    // mock addUser resets to initial memory state before each test runs
    beforeEach(()=> {
        addUser.mockReset()
    })

    // database mocked interaccion tests
    describe('given a name and password', ()=>{
        test('should save the name and password to database once', async()=>{
            const response = await request(app).post('/user').send({
                name: "jcsTestName1",
                password: "jcsTestPass1"
            })
            expect(addUser.mock.calls.length).toBe(1)
            expect(addUser.mock.calls[0][0].name).toBe("jcsTestName1")
            // to test for the password a mock for bcrypt should be written
            // expect(addUser.mock.calls[0][1]).toBe('jcsTestPass1')
        })
    })

    describe('given a name and password', ()=>{

        test('it should respond with status  200', async ()=>{
            const response = await request(app).post('/user').send({
                name: "jcsTest1",
                password: "jcsTest1"
            })
            expect(response.statusCode).toBe(200)
        })

        test('it should respond with json header', async ()=>{
            const response = await request(app).post('/user').send({
                name: "jcsTest1",
                password: "jcsTest1"
            })
            expect(response.headers['content-type'].split(';')[0]).toEqual('application/json')
        })

        test('response object should contain users name', async ()=>{
            const response = await request(app).post('/user').send({
                name: "jcsTest1",
                password: "jcsTest1"
            })
            expect(response.body.name).toBeDefined()
            // expect(response.body.name).toEqual('jcsTest1')
        })

        test('it should return 400 code if request data is missing', async ()=>{
            const response = await request(app).post('/user').send({
                name: "jcsTest1",
                // missing password
            })
            expect(response.statusCode).toBe(400)
        })
    })
})

