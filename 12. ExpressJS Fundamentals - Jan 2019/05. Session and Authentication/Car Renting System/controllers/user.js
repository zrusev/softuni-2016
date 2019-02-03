const encryption = require('../util/encryption');
const User = require('../models/User');
const Rent = require('../models/Rent');

module.exports = {
    registerGet: (req, res) => {
        res.render('user/register');
    },
    registerPost: async (req, res) => {
        const userBody = req.body;

        if (!userBody.username || !userBody.password || !userBody.repeatPassword) {
            userBody.error = 'Please fill all fields!';
            res.render('user/register', userBody);
            return;
        }

        if (userBody.password !== userBody.repeatPassword) {
            userBody.error = 'Both password should match!';
            res.render('user/register', userBody);
            return;
        }

        let salt = encryption.generateSalt();
        let hashedPass = encryption.generateHashedPassword(salt, userBody.password);

        try {
            const user = await User.create({
                username: userBody.username,
                hashedPass,
                firstName: userBody.firstName,
                lastName: userBody.lastName,
                salt,
                roles: ['User']
            });

            req.logIn(user, (err) => {
                if (err) {
                    userBody.error = err;
                    res.render('user/register', userBody);
                } else {
                    res.redirect('/');
                }
            });
        } catch (error) {
            console.log(error);
        }
    },
    logout: (req, res) => {
        req.logout();
        res.redirect('/');
    },
    loginGet: (req, res) => {
        res.render('user/login');
    },
    loginPost: async (req, res) => {
        const userBody = req.body;

        try {
            const user = await User.findOne({
                username: userBody.username
            });

            if (!user) {
                userBody.error = 'Username is invalid!';
                res.render('user/login', userBody);
                return;
            }

            if (!user.authenticate(userBody.password)) {
                userBody.error = 'Password is invalid!';
                res.render('user/login', userBody);
                return;
            }

            req.logIn(user, (err) => {
                if (err) {
                    userBody.error = err;
                    res.render('user/login', userBody);
                } else {
                    res.redirect('/');
                }
            });
        } catch (error) {
            console.log(error);
            userBody.error = 'Something went wrong!';
            res.render('user/login', userBody);
        }
    },
    myRents: async (req, res) => {
        try {
            const userId = req.user._id;
            const cars = await Rent
                .find({ owner: userId})
                .populate('car')

            res.render('user/rented', { cars });
        } catch (error) {
            console.log(error);            
        }
    }
};