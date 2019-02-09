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

        if (!reqUser.password || !reqUser.confirmPassword) {
            errorHandler(message.requiredPassword, res, 'users/register', reqUser);
            return;            
        }

        if (reqUser.password !== reqUser.confirmPassword) {
            errorHandler(message.passwordsDoNotMatch, res, 'users/register', reqUser);
            return;
        }

        const salt = encryption.generateSalt();
        const hashedPass = encryption.generateHashedPassword(salt, reqUser.password);
        
        try {
            const user = await User.create({
                email: reqUser.email,
                hashedPass,
                salt,
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

        try {
            const user = await User.findOne({ email: reqUser.email });

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