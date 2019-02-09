const Thread = require('../models/Thread');
const errorHandler = require('../util/errorHandler');

module.exports = {
    index: (req, res) => {

        if (req.isAuthenticated() && req.user.roles.indexOf('Admin') > -1) {
            Thread
                .find({})
                .populate('users')
                .then((threads) => {
                    res.render('home/index', { threads });
                    return;
                })
                .catch((err) => {
                    errorHandler(err, res, 'home/index');
                    return;
                });
        } else {
            res.render('home/index');
        }
    }
};