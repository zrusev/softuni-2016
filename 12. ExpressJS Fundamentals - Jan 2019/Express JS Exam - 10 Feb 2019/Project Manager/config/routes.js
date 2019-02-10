const controllers = require('../controllers');
const restrictedPages = require('./auth');

module.exports = app => {
    app
        .get('/', controllers.home.index)

        .get('/register', restrictedPages.isAnonymous, controllers.user.registerGet)
        .post('/register', restrictedPages.isAnonymous, controllers.user.registerPost)
        .get('/login', restrictedPages.isAnonymous, controllers.user.loginGet)
        .post('/login', restrictedPages.isAnonymous, controllers.user.loginPost)
        .post('/logout', restrictedPages.isAuthed, controllers.user.logout)

        .get('/profile', restrictedPages.isAuthed, controllers.home.profile)

        .get('/teams/create', restrictedPages.hasRole('Admin'), controllers.team.getCreate)
        .post('/teams/create', restrictedPages.hasRole('Admin'), controllers.team.postCreate)
        .get('/teams/distribute/:errorMessage?', restrictedPages.hasRole('Admin'), controllers.team.getDistribute)
        .post('/teams/distribute', restrictedPages.hasRole('Admin'), controllers.team.postDistribute)
        .get('/teams/all', restrictedPages.isAuthed, controllers.team.getAll)
        .get('/teams/leave-team/:teamId', restrictedPages.isAuthed, controllers.team.leaveTeam)
        .post('/teams/search', restrictedPages.isAuthed, controllers.team.search)

        .get('/projects/create', restrictedPages.hasRole('Admin'), controllers.project.getCreate)
        .post('/projects/create', restrictedPages.hasRole('Admin'), controllers.project.postCreate)
        .get('/projects/distribute', restrictedPages.hasRole('Admin'), controllers.project.getDistribute)
        .post('/projects/distribute', restrictedPages.hasRole('Admin'), controllers.project.postDistribute)
        .get('/projects/all', restrictedPages.isAuthed, controllers.project.getAll)
        .post('/projects/search', restrictedPages.isAuthed, controllers.project.search)

        .all('*', (req, res) => {
            res.status(404);
            res.send('404 Not Found');
            res.end();
        });
};