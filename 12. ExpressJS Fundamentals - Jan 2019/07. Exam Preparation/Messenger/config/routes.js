const controllers = require('../controllers');
const restrictedPages = require('./auth');

module.exports = app => {
    app.get('/', controllers.home.index);
    
    app.get('/users/register', restrictedPages.isAnonymous, controllers.user.registerGet);
    app.post('/users/register', restrictedPages.isAnonymous, controllers.user.registerPost);
    
    app.get('/users/login', restrictedPages.isAnonymous, controllers.user.loginGet);
    app.post('/users/login', restrictedPages.isAnonymous, controllers.user.loginPost);
    
    app.get('/users/logout', restrictedPages.isAuthed, controllers.user.logout);
    
    app.post('/threads/find', restrictedPages.isAuthed, controllers.thread.find);
    app.get('/thread/:otherUser', restrictedPages.isAuthed, controllers.thread.getThread);
    app.post('/thread/:otherUser', restrictedPages.isAuthed, controllers.thread.postThread);

    app.post('/block/:username', restrictedPages.isAuthed, controllers.thread.block);
    app.post('/unblock/:otherUser', restrictedPages.isAuthed, controllers.thread.unBlock);

    app.post('/threads/remove/:threadId', restrictedPages.hasRole('Admin'), controllers.thread.deleteThread);

    app.all('*', (req, res) => {
        res.status(404);
        res.send('404 Not Found');
        res.end();
    });
};