const User = require('mongoose').model('User');

module.exports.loginPost = (req, res) => {
    let userToLogin = req.body;

    User.findOne({
        username: userToLogin.username
    }).then((user) => {
        if (!user || !user.authenticate(userToLogin.password)) {
            res.render('user/login', {
                error: 'Invalid credentials!'
            });
        } else {
            req.logIn(user, (error, user) => {
                if (error) {
                    res.render('user/login', {
                        error: 'Authentication not working!'
                    });
                    return;
                }
                
                res.redirect('/');
            });
        }
    })
}