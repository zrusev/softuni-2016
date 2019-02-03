const restrictedPages = require('./auth');
const homeController = require('../controllers/home');
const usersController = require('../controllers/user');
const carsController = require('../controllers/car')

module.exports = app => {
    app
        .get('/', homeController.index)
        .get('/user/register', restrictedPages.isAnonymous, usersController.registerGet)
        .post('/user/register', restrictedPages.isAnonymous, usersController.registerPost)
        .get('/user/login', restrictedPages.isAnonymous, usersController.loginGet)
        .post('/user/login', restrictedPages.isAnonymous, usersController.loginPost)
        .post('/user/logout', restrictedPages.isAuthed, usersController.logout)
        .get('/user/rents', restrictedPages.isAuthed, usersController.myRents)

        .get('/car/add', restrictedPages.hasRole('Admin'), carsController.addGet)
        .post('/car/add', restrictedPages.hasRole('Admin'), carsController.addPost)
        .get('/car/all', carsController.allCars)
        .get('/search', carsController.search)

        .get('/car/rent/:id', restrictedPages.isAuthed, carsController.rentGet)
        .post('/car/rent/:id', restrictedPages.isAuthed, carsController.rentPost)   

        .get('/car/edit/:id', restrictedPages.isAuthed, carsController.editGet)
        .post('/car/edit/:id', restrictedPages.isAuthed, carsController.editPost)

        .all('*', (req, res) => {
            res.status(404);
            res.send('404 Not Found');
            res.end();
        });
};