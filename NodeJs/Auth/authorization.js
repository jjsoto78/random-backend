const express = require('express')
const app = express()
app.use(express.json())
const jwt = require('jsonwebtoken')
// allows to query data from process.env
require('dotenv').config()


app.post('/login', (req, res)=>{
    // Authenthicate user
    const username = req.body.username
    const user = {name : username}

    //jwt.sign() creates a new jwt encryted object contaning user and token_secret data, this object contains all necessary data to decrypt it, so veryfing the token takes place at server.js
    const accessToken = jwt.sign(user, process.env.TOKEN_SECRET, {expiresIn : '15s'})
    
    // refresh token is used to validate when to create another access token 
    const refreshToken = jwt.sign(user, process.env.REFRESH_TOKEN_SECRET )
    refreshTokens.push(refreshToken)

    // {accessToken : accessToken}
    return res.send({accessToken, refreshToken})
}) 

let refreshTokens = []

app.post('/refreshToken', (req, res)=>{
    // Authenthicate user
    const refreshToken = req.body.refreshToken

    if(!refreshToken) return res.status(401)
    if(!refreshTokens.includes(refreshToken)) return res.status(403)

    jwt.verify(refreshToken, process.env.REFRESH_TOKEN_SECRET, (err, user)=>{
        if(err) return res.status(403)
        const newAccessToken = jwt.sign({name : user.name}, process.env.TOKEN_SECRET, {expiresIn : '15s'})

        return res.json({accessToken : newAccessToken})
    })

}) 

app.delete('/logout', (req, res) => {
    refreshTokens = [refreshTokens.filter(t => t !== req.body.refreshToken)]
    return res.sendStatus(204)
})

app.listen(4000, ()=>{
    console.log('jcs Authorization server running')
})