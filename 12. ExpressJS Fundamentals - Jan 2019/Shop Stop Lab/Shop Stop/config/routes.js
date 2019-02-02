const controllers = require('../controllers');
const multer = require('multer');
const auth = require('./auth');

var storage = multer.diskStorage({
    destination: function (req, file, cb) {
        cb(null, './content/images/')
    },
    filename: function (req, file, cb) {
        cb(null, file.fieldname + '_' + Date.now() + '.' + file.originalname.split('.')[1])
    }
})

let upload = multer({
    storage: storage
});

module.exports = (app) => {
    app
        .get('/', controllers.home.index)
        .get('/product/add', auth.isAuthenticated, controllers.product.get.addGet)
        .post('/product/add', auth.isAuthenticated, upload.single('image'), controllers.product.post.addPost)
        .get('/category/add', auth.isInRole('Admin'), controllers.category.get.addGet)
        .post('/category/add', auth.isInRole('Admin'), controllers.category.post.addPost)
        .get('/category/:category/products', controllers.category.get.productByCategory)
        .get('/product/edit/:id', auth.isAuthenticated, controllers.product.get.editGet)
        .post('/product/edit/:id', auth.isAuthenticated, upload.single('image'), controllers.product.post.editPost)
        .get('/product/delete/:id', auth.isAuthenticated, controllers.product.get.deleteGet)
        .post('/product/delete/:id', auth.isAuthenticated, controllers.product.post.deletePost)
        .get('/product/buy/:id', auth.isAuthenticated, controllers.product.get.buyGet)
        .post('/product/buy/:id', auth.isAuthenticated, controllers.product.post.buyPost)
        .get('/user/register', controllers.user.get.registerGet)
        .post('/user/register', controllers.user.post.registerPost)
        .get('/user/login', controllers.login.get.loginGet)
        .post('/user/login', controllers.login.post.loginPost)
        .post('/user/logout', controllers.logout.logout);
}