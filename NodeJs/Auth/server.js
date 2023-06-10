const express = require('express')
const app = express()
app.use(express.json())
const bcrypt = require('bcrypt')
const jwt = require('jsonwebtoken')
// allows to query data from process.env
require('dotenv').config()

const users = [];

const cards = [
{
    username: 'Yuri',
    cardname:  'Dark Magician Girl'
},
{
    username: 'Yuri',
    cardname:  'Dark Yuri Magic'
},
{
    username: 'Karin',
    cardname:  'Empress King'
}
]

app.get('/resource', validateToken, (req, res)=>{
    const username = req.user.name

    userCards = cards.filter(c => c.username === username).map(c =>c.cardname)

    res.send(userCards)
})


// middleware for token validation
function validateToken(req, res, next){
    // token comes in the headers
    const reqHeader = req.headers['authorization']
    const token = reqHeader && reqHeader.split(' ')[1]

    if(!token) return res.sendStatus(401)

    jwt.verify(token, process.env.TOKEN_SECRET, (err, user)=>{
        if(err) return res.sendStatus(403)
        req.user = user
        next()
    })
}

app.listen(3000, ()=>{
    console.log('jcs server running')
})