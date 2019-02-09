const controllers = require('../controllers');
const restrictedPages = require('./auth');

module.exports = app => {
    app
        .get('/', controllers.home.index)
        .get('/register', restrictedPages.isAnonymous, controllers.user.registerGet)
        .post('/register', restrictedPages.isAnonymous, controllers.user.registerPost)
        .get('/login', restrictedPages.isAnonymous, controllers.user.loginGet)
        .post('/login', restrictedPages.isAnonymous, controllers.user.loginPost)
        .get('/logout', restrictedPages.isAuthed, controllers.user.logout)    
        .get('/create', restrictedPages.isAuthed, controllers.article.getCreate)
        .post('/create', restrictedPages.isAuthed, controllers.article.postCreate)
        .get('/all-articles', controllers.article.getAll)
        .get('/all-articles/:id', controllers.article.getOne)
        .get('/edit/:id', restrictedPages.isAuthed, controllers.article.getEdit)
        .post('/edit/:id', restrictedPages.isAuthed, controllers.article.postEdit)
        .get('/history/:id', restrictedPages.isAuthed, controllers.article.getHistory)
        .get('/lockedStatus/:id', restrictedPages.hasRole('Admin'), controllers.article.lockUnlock)

        .all('*', (req, res) => {
            res.status(404);
            res.send('404 Not Found');
            res.end();
        });
};