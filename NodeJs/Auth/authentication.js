// AUTHENTICATION server

const express = require("express");

function appWithDI(database, encryptionEngine) {
  const app = express();
  const bcrypt = encryptionEngine
  // const users = []
  app.use(express.json());

  app.post("/user", async (req, res) => {
    // no good to store passwords as text, need to encypt data
    //hashed password is an encrypted object created from original password + salt(random)
    // const user = { name: req.body.name, password: req.body.password }

    try {
      if (!req.body.name || !req.body.password) return res.status(400).end();
      const salt = await bcrypt.genSalt();
      const hashedPassword = await bcrypt.hash(req.body.password, salt);
      const user = { name: req.body.name, password: hashedPassword };

    //   users.push(user);
      database.addUser(user)
      res.send(user).status(201);
    } catch (error) {
      return res.status(500).end();
    }
  });

  app.post("/login", async (req, res) => {
    // no good to store passwords as text, need to encypt data
    //hashed password is an encrypted object created from original password + salt(random)
    //user data is stored in the hashed password like in a web token, so the encryption algorithim knows how to get data back
    // const user = { name: req.body.name, password: req.body.password }

    try {
      //  throw new Error({'hehe':'haha'});
    //   const user = users.find((u) => u.name === req.body.name);
      const user = database.getUsers().find((u) => u.name === req.body.name);

      if (!user) return res.send("user not found").status(404);

      // is important to use bcrypt to compare incoming password with db hashed password
      if (!(await bcrypt.compare(req.body.password, user.password)))
        return res.send("Not allowed").status(400)

      res.send({message:"Login Success", name: req.body.name}).end(
        
      )
    } catch (error) {
      res.status(500).end()
    }
  });

  return app
}

module.exports = { appWithDI };
