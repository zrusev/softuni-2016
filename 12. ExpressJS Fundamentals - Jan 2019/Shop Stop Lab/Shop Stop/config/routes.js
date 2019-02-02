const handlers = require('../handlers');
const multer = require('multer');

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
        .get('/', handlers.home.index)
        .get('/product/add', handlers.product.get.addGet)
        .post('/product/add', upload.single('image'), handlers.product.post.addPost)
        .get('/category/add', handlers.category.get.addGet)
        .post('/category/add', handlers.category.post.addPost)
        .get('/category/:category/products', handlers.category.get.productByCategory)
        .get('/product/edit/:id', handlers.product.get.editGet)
        .post('/product/edit/:id', upload.single('image'), handlers.product.post.editPost)
        .get('/product/delete/:id', handlers.product.get.deleteGet)
        .post('/product/delete/:id', handlers.product.post.deletePost)
        .get('/product/buy/:id', handlers.product.get.buyGet)
        .post('/product/buy/:id', handlers.product.post.buyPost);
}