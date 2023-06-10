const express = require('express')
const app = express()

app.use(express.json())

const usersRouter = require('./Routes/users.js')
app.use(usersRouter)

app.listen(3003, () => {
    console.log('jcs server started')
    // console.log(module)
    console.log(`file name is: ${__filename}`);
    console.log(`dir name is: ${__dirname}`);
})

// word wrap on vscode settings ssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssss