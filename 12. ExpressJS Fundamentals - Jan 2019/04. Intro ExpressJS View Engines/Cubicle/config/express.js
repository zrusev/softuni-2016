const express = require('express');
const handlebars = require('express-handlebars');
const bodyParser = require('body-parser');
const cubeModel = require('../models/cubeModel');

module.exports = app => {
    app.engine('.hbs', handlebars({
        defaultLayout: 'main',
        extname: '.hbs'
    }));

    app.use(bodyParser.urlencoded({
        extended: true
    }));

    app.set('/', cubeModel);
    app.set('view engine', '.hbs');
    
    app.use(express.static('./static'));
};