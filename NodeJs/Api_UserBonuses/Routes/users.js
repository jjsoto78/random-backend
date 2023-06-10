const express = require("express");
// Router() returns a new instace
const router = express.Router();

const {  
  getUsersData,
  getSubscriptionsData,
  getBonusesData,
} = require("../Data/appData");


const {} =require("../Data/appData");
const getAllUsers = (req, res) => {
  // res.send('Give me a ton of gold')
  // res.send(users).status(200)
  getUsersData().then((response) => {
    res.send(response).status(200);
  });
};

async function asssingUserBonus() {
  let userBonuses = [];
  const users = await getUsersData();
  // const subscriptions = await getSubscriptionsData()
  const bonuses = await getBonusesData();

  users.map((e) => {
    const bonus = bonuses.find((b) => b.subscription === e.subscription)?.bonus;
    // console.log(e.name)
    // console.log(bonus)
    const userBonus = {};
    userBonus.user = e.name;
    userBonus.bonus = bonus;

    // userBonuses.push(userBonus)
    userBonuses = [...userBonuses, userBonus];
  });

  return userBonuses;
}

const getAllUsersBonus = async (req, res) => {
  // res.send('Give me a ton of gold')
  // res.send(users).status(200)
  res.send(await asssingUserBonus()).status(200);
};

// const getOneUser = async (req, res) => {
//     // const user = users.find(e => e.id.toString() === req.params.id)
//     res.send(res.user).status(200)
// }

// // below middleware is used to encapsulate shared code amongst action methods
// async function getUser(req, res, next) {
//     let user;
//     try {
//         user = users.find(e => e.id.toString() === req.params.id)
//         // throw new Error('Throw makes it go boom!')
//         if (!user)
//             return res.status(404).json({ message: 'user not found' })
//     } catch (error) {
//         return res.status(500).json({ message: error.message })
//     }

//     res.user = user
//     next()
// }

//  instance object properties filling up
router.get(["/"], getAllUsers);
router.get(["/bonus"], getAllUsersBonus);

// this is using middleware, so on a route, first executes getUser() then next() within executes getAllUsers
// notice that middleware, promises, async await and callbacks are means to execute code synchronosly
// router.get('/:id', getUser, getOneUser)

// then export the router object
module.exports = router;
