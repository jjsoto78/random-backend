// AUTHENTICATION server
// separate the endpoints from the server for superuser testing and TDD
const database = require('./authDataBase')
// const {app} = require('./authentication')
const { appWithDI } = require('./authentication')

// adding ecryption engine to DI so it can be mocked in tests
const bcrypt = require("bcrypt")
const encryptionEngine = bcrypt


// database layer gets injected into the endpoint, with this we can mock the database, change database layer, etc, endpoint code is loosely coupled
const app = appWithDI(database, encryptionEngine)
app.listen(5000, ()=>{
    console.log('jcs Authentication server running')
})