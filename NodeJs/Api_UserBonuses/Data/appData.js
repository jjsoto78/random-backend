
const users = [
    {
        id: 111,
        name: 'Mathias',
        subscription: 'Premium',
        email: 'maaa@imail.com'
    },
    {
        id: 222,
        name: 'Rinny',
        subscription: 'Standard',
        email: 'rees@imail.com'
    },
    {
        id: 333,
        name: 'Stu',
        subscription: 'Unsubscribed',
        email: 'stu2@imail.com'
    },
    {
        id: 444,
        name: 'Marie',
        subscription: 'Premium',
        email: 'maux77@imail.com'
    },
]

const subscriptionTypes = [
    {
        id: 1,
        subscription: 'Premium'
    },
    {
        id: 2,
        subscription: 'Standard'
    },
    {
        id: 3,
        subscription: 'Unsubscribed'
    },
    {
        id: 0,
        subscription: 'none'
    },
]

const subscriptionBonusses = [
    {
        id: 11,
        subscription: 'Premium',
        bonus: '50 extra Movie Views'
    },
    {
        id: 22,
        subscription: 'Standard',
        bonus: '15 extra TV Channels'
    },
    {
        id: 33,
        subscription: 'Unsubscribed',
        bonus: '50% cashback upon renewal'
    },

]

async function sleep(ms) {
    return new Promise(resolve => setTimeout(resolve, ms));
}


async function getUsersData() {
    const delay = 3000
    await sleep(delay).then(() => { console.log(`Delayed ${delay} seconds`); });

    return new Promise(
        resolve => { resolve(users) }
    )
}

function getSubscriptionsData() {
    return new Promise(
        (resolve, reject) => { resolve(subscriptionTypes) }
    )
}
function getBonusesData() {
    return new Promise(
        (resolve, reject) => { resolve(subscriptionBonusses) }
    )
}
// lets create an object to contain all the exported values
//module is a node global object
// de-esctructure on consuming
module.exports = { getUsersData, getSubscriptionsData, getBonusesData }