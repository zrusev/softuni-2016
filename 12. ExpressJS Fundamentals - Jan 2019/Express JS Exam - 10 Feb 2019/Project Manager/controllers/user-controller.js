const encryption = require('../util/encryption');
const User = require('mongoose').model('User');
const errorHandler = require('../util/errorHandler');
const message = require('../common/message');

module.exports = {
    registerGet: (req, res) => {
        res.render('users/register');
    },
    registerPost: async (req, res) => {
        const reqUser = req.body;

        if (!reqUser.password) {
            errorHandler(message.requiredPassword, res, 'users/register', reqUser);
            return;            
        }

        const salt = encryption.generateSalt();
        const hashedPass = encryption.generateHashedPassword(salt, reqUser.password);
        
        try {
            const user = await User.create({
                username: reqUser.username,
                hashedPass,
                salt,
                profilePicture: reqUser.profilePicture,
                firstName: reqUser.firstName,
                lastName: reqUser.lastName,
                roles: ['User']
            });
        
            req.logIn(user, (err, user) => {
                if (err) {
                    errorHandler(err, res, 'users/register', user);
                } else {
                    res.redirect('/');
                }
            });
        } catch (err) {
            errorHandler(err, res, 'users/register', reqUser);
        }
    },
    logout: (req, res) => {
        req.logout();
        res.redirect('/');
    },
    loginGet: (req, res) => {
        res.render('users/login');
    },
    loginPost: async (req, res) => {        
        const reqUser = req.body;

        if (!reqUser.username || !reqUser.password) {
            errorHandler(message.requiredFields, res, 'users/login');
            return;
        }

        try {
            const user = await User.findOne({ username: reqUser.username });

            if (!user) {
                errorHandler(message.invalidUserData, res, 'users/login');
                return;
            }

            if (!user.authenticate(reqUser.password)) {
                errorHandler(message.invalidUserData, res, 'users/login');
                return;
            }

            req.logIn(user, (err, user) => {
                if (err) {
                    errorHandler(err, res, 'users/login');
                } else {
                    res.redirect('/');
                }
            });
        } catch (err) {
            errorHandler(err, res, 'users/login');
        }
    }
};