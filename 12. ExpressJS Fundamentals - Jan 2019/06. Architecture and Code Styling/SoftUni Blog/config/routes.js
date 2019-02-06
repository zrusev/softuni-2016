const homeController = require('../controllers/home');
const usersController = require('../controllers/user');
const articlesController = require('../controllers/article');
const restrictedPages = require('../config/auth');

module.exports = (app) => {
    app.get('/', homeController.index);
    app.get('/user/register', restrictedPages.isAnonymous, usersController.registerGet);
    app.post('/user/register', restrictedPages.isAnonymous, usersController.registerPost);

    app.get('/user/login', restrictedPages.isAnonymous, usersController.loginGet);
    app.post('/user/login', restrictedPages.isAnonymous, usersController.loginPost);

    app.get('/user/logout', restrictedPages.isAuthed, usersController.logout);
    
    app.get('/article/create', restrictedPages.isAuthed, articlesController.getCreate);
    app.post('/article/create', restrictedPages.isAuthed, articlesController.postCreate);

    app.get('/article/details/:id', articlesController.getDetails);

    app.get('/article/edit/:id', restrictedPages.isAuthed, articlesController.getEdit);
    app.post('/article/edit/:id', restrictedPages.isAuthed, articlesController.postEdit);

    app.get('/article/delete/:id', restrictedPages.isAuthed, articlesController.getDelete);
    app.post('/article/delete/:id', restrictedPages.isAuthed, articlesController.postDelete);
};

