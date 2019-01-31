const homeController = require('../controllers/home');
const cubeController = require('../controllers/cube');

module.exports = app => {
    app
        .get('/', homeController.homeGet)
        .get('/about', homeController.about)
        .get('/create', cubeController.createGet)
        .post('/create', cubeController.createPost)
        .get('/details/:id', cubeController.details)
        .get('/search', homeController.search);
};