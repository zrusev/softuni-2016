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

            if (product.buyer) {
                res.redirect(`/?error=${encodeURIComponent('Product has already been bought!')}`);
                return;
            }

            if (product.creator.equals(req.user._id) || req.user.roles.indexOf('Admin') >= 0) {
                Category.find()
                    .then((categories) => {
                        res.render('product/edit', {
                            product: product,
                            categories: categories
                        });
                    });
            } else {
                res.redirect(`/?error=${encodeURIComponent("You don't have access to this resource!")}`);
                return;
            }
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

            if (product.buyer) {
                res.redirect(`/?error=${encodeURIComponent('Product has already been bought!')}`);
                return;
            }

            if (product.creator.equals(req.user._id) || req.user.roles.indexOf('Admin') >= 0) {
                res.render('product/delete', {
                    product: product
                });
            } else {
                res.redirect(`/?error=${encodeURIComponent("You don't have access to this resource!")}`);
                return;
            }
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