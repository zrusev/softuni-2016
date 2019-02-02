const homeHandler = require('./home.js');
const productGetHandler = require('./productGet');
const productPostHandler = require('./productPost');
const categoryGetHandler = require('./categoryGet');
const categoryPostHandler = require('./categoryPost');

module.exports = {
    home: homeHandler,
    product: {
        get: productGetHandler,
        post: productPostHandler
    },
    category: {
        get: categoryGetHandler,
        post: categoryPostHandler
    }
};