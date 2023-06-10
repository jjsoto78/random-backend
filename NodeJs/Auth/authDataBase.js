const users = []

function getUsers()
{
    return users
}

function addUser(user)
{
    return users.push(user)
}

module.exports = {getUsers, addUser}