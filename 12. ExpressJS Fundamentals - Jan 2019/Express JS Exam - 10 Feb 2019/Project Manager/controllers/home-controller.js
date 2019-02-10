const User = require('mongoose').model('User');
const Team = require('../models/Team');
const Project = require('../models/Project');
const errorHandler = require('../util/errorHandler');

module.exports = {
    index: (req, res) => {
        res.render('home/index');
    },
    profile: (req, res) => {
        User.findById(req.user._id)
            .populate({
                path: 'teams',
                populate: {
                    path: 'projects'
                }
            })
            .then((user) => {
                res.render('home/profile', user);
            })
            .catch((err) => {
                errorHandler(err, res, 'home/profile');
            });
    }
};