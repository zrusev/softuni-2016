const path = require('path');
const fs = require('fs');
const Product = require('../models/Product');
const Category = require('../models/Category');

module.exports.addPost = async (req, res) => {
    let productObj = req.body;
    productObj.image = path.normalize(path.join(req.file.destination, req.file.filename));
    productObj.creator = req.user._id;

    let product = await Product.create(productObj);
    let category = await Category.findById(product.category);
    category.products.push(product._id);
    category.save()
        .then(() => {
            res.redirect('/');
            return;
        });
}

module.exports.editPost = async (req, res) => {
    let id = req.params.id;
    let editedProduct = req.body;

    let product = await Product.findById(id);
    if (!product) {
        res.redirect(`error=${encodeURIComponent('Product was not found!')}`);
        return;
    }

    if (product.buyer) {
        res.redirect(`/?error=${encodeURIComponent('Product has already been bought!')}`);
        return;
    }

    product.name = editedProduct.name;
    product.description = editedProduct.description;
    product.price = editedProduct.price;

    if (req.file) {
        product.image = path.normalize(path.join(req.file.destination, req.file.filename));
    }

    if (product.category.toString() !== editedProduct.category) {
        if (product.creator.equals(req.user._id) || req.user.roles.indexOf('Admin') >= 0) {
            Category.findById(product.category)
                .then((currentCategory) => {
                    Category.findById(editedProduct.category)
                        .then((nextCategory) => {
                            let index = currentCategory.products.indexOf(product._id);
                            if (index >= 0) {
                                currentCategory.products.splice(index, 1);
                            }
                            currentCategory.save();

                            nextCategory.products.push(product._id);
                            nextCategory.save();

                            product.category = editedProduct.category;

                            product.save()
                                .then(() => {
                                    res.redirect(`/?success=${encodeURIComponent('Product was edited successfully!')}`);
                                });
                        });
                });
        } else {
            res.redirect(`/?error=${encodeURIComponent("You don't have access to this resource!")}`);
            return;
        }
    } else {
        product.save()
            .then(() => {
                res.redirect(`/?success=${encodeURIComponent('Product was edited successfully!')}`);
            });
    }
}

module.exports.deletePost = async (req, res) => {
    let id = req.params.id;

    let product = await Product.findById(id);
    if (!product) {
        res.redirect(`error=${encodeURIComponent('Product was not found!')}`);
        return;
    }

    if (product.buyer) {
        res.redirect(`/?error=${encodeURIComponent('Product has already been bought!')}`);
        return;
    }

    if (product.creator.equals(req.user._id) || req.user.roles.indexOf('Admin') >= 0) {
        //delete product from collection
        Product.findByIdAndDelete(id)
            .then(() => {
                //delete image
                fs.unlink(product.image, (err) => {
                    if (err) {
                        console.log(err);
                        res.redirect(`error=${encodeURIComponent('Picture was not found!')}`);
                        return;
                    }

                    //delete category reference
                    Category.findById(product.category)
                        .then((currentCategory) => {
                            let index = currentCategory.products.indexOf(product._id);
                            if (index >= 0) {
                                currentCategory.products.splice(index, 1);
                            }
                            currentCategory.save();

                            //redirect
                            res.redirect(`/?success=${encodeURIComponent('Product was deleted successfully!')}`);
                        })
                        .catch((err) => {
                            console.log(err);
                            res.redirect(`error=${encodeURIComponent('Could not delete category!')}`);
                            return;
                        });
                });
            })
            .catch((err) => {
                console.log(err);
                res.redirect(`error=${encodeURIComponent('Could not delete product!')}`);
                return;
            });
    } else {
        res.redirect(`/?error=${encodeURIComponent("You don't have access to this resource!")}`);
        return;
    }
}

module.exports.buyPost = (req, res) => {
    let productId = req.params.id;

    Product.findById(productId)
        .then((product) => {
            if (product.buyer) {
                let error = `error=${encodeURIComponent('Product was already bought!')}`;
                res.redirect(`/?${error}`);
                return;
            }

            product.buyer = req.user._id;
            product.save()
                .then(() => {
                    req.user.boughtProducts.push(productId);
                    req.user.save()
                        .then(() => {
                            res.redirect('/');
                        });
                });
        });
}