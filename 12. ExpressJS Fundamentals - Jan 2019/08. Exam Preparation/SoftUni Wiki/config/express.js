const express = require('express');
const handlebars = require('express-handlebars');
const cookieParser = require('cookie-parser');
const bodyParser = require('body-parser');
const session = require('express-session');
const path = require('path');
const passport = require('passport');

module.exports = (app, config) => {
    app.engine('.hbs', handlebars({
        defaultLayout: 'main',
        extname: '.hbs',
        helpers: {
            dateFormat: require('handlebars-dateformat')
        }
    }));

    app.use(cookieParser());
    app.use(bodyParser.urlencoded({extended: true}));
    app.use(session({
        secret: '123456',
        resave: false,
        saveUninitialized: false
    }));
    app.use(passport.initialize());
    app.use(passport.session());

    app.use((req, res, next) => {
        if (req.user) {
            res.locals.currentUser = req.user;
        }
        next();
    });

    app.use((req, res, next) => {
        if (req.isAuthenticated() && req.user.roles.indexOf('Admin') > -1) {
            res.locals.isAdmin = true;
        } 
        next();
    });

    app.use((req, res, next) => {
        if (req.isAuthenticated()) {
            res.locals.isAuth = true;
        }        
        next();
    });

    app.set('view engine', '.hbs');

    app.use(express.static(path.join(config.rootFolder, 'static')));
};