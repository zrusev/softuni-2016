const express = require('express');
const path = require('path');
const bodyParser = require('body-parser');
const handlebars = require('express-handlebars');

module.exports = (app, config) => {
    app.engine('.hbs', handlebars({
        defaultLayout: 'layout',
        extname: '.hbs'
    }));

    app.set('view engine', '.hbs');

    app.use(bodyParser.urlencoded({
        extended: true
    }));

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