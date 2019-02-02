const homeHandler = require('./home.js');
const productGetHandler = require('./productGet');
const productPostHandler = require('./productPost');
const categoryGetHandler = require('./categoryGet');
const categoryPostHandler = require('./categoryPost');
const userGetHandler = require('./userGet');
const userPostHandler = require('./userPost');
const loginGetHandler = require('./loginGet');
const loginPostHandler = require('./loginPost');
const logoutHandler = require('./logout');

module.exports = {
    home: homeHandler,
    product: {
        get: productGetHandler,
        post: productPostHandler
    },
    category: {
        get: categoryGetHandler,
        post: categoryPostHandler
    },
    user: {
        get: userGetHandler,
        post: userPostHandler
    },
    login: {
        get: loginGetHandler,
        post: loginPostHandler
    },
    logout: logoutHandler
};