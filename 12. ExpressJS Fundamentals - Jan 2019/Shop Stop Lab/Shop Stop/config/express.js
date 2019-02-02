const express = require('express');
const path = require('path');
const bodyParser = require('body-parser');
const handlebars = require('express-handlebars');
const cookieParser = require('cookie-parser');
const session = require('express-session');
const passport = require('passport');

module.exports = (app, config) => {
    app.engine('.hbs', handlebars({
        defaultLayout: 'layout',
        extname: '.hbs'
    }));

    app.set('view engine', '.hbs');

    app.use(bodyParser.urlencoded({
        extended: true
    }));

    app.use(cookieParser());
    app.use(session({
        secret: 'S3cr3t',
        saveUninitialized: false,
        resave: false
    }));
    app.use(passport.initialize());
    app.use(passport.session());

    app.use((req, res, next) => {
        if (req.user) {
            res.locals.user = req.user;
        }

        next();
    })

    app.use((req, res, next) => {
        //Route: /content/images/.*
        if (req.url.startsWith('/content')) {
            req.url = req.url.replace('/content', '');
        }

        //Route: /category/.*/content/images/.*
        if (RegExp(/^\/category\/.*\/content.*/i).test(req.url)) {
            req.url = req.url.replace(/^\/category\/.*\/content/i, '');
        }

        //Route: /product/(delete|buy)/content/images/.*
        if (RegExp(/^\/product\/(delete|buy)\/content.*/i).test(req.url)) {
            req.url = req.url.replace(/^\/product\/(delete|buy)\/content/i, '');
        }

        next();
    }, express.static(path.normalize(path.join(config.rootPath, 'content'))));
}