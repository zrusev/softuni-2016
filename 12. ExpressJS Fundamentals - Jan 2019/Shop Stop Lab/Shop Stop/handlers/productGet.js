const Product = require('../models/Product');
const Category = require('../models/Category');

module.exports.addGet = (req, res) => {

    Category.find({})
        .then((categories) => {
            res.render('product/add', {
                categories: categories
            });
        });
}
module.exports.editGet = (req, res) => {
    let id = req.params.id;

    Product.findById(id)
        .then((product) => {
            if (!product) {
                res.sendStatus(404);
                return;
            }

            Category.find({})
                .then((categories) => {
                    res.render('product/edit', {
                        product: product,
                        categories: categories
                    });
                });
        });
}

module.exports.deleteGet = (req, res) => {
    let id = req.params.id;

    Product.findById(id)
        .then((product) => {
            if (!product) {
                res.sendStatus(404);
                return;
            }

            res.render('product/delete', {
                product: product
            });
        });
}

module.exports.buyGet = (req, res) => {
    let id = req.params.id;

    Product.findById(id)
        .then((product) => {
            if (!product) {
                res.sendStatus(404);
                return;
            }

            Category.find({})
                .then((categories) => {
                    res.render('product/buy', {
                        product: product,
                        categories: categories
                    });
                });
        });
}