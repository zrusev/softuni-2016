const path = require('path');
const fs = require('fs');
const Product = require('../models/Product');
const Category = require('../models/Category');

module.exports.addPost = async (req, res) => {
    let productObj = req.body;
    productObj.image = path.normalize(path.join(req.file.destination, req.file.filename));

    let product = await Product.create(productObj);
    let category = await Category.findById(product.category);
    category.products.push(product._id);
    category.save();
    res.redirect('/');
}

module.exports.editPost = async (req, res) => {
    let id = req.params.id;
    let editedProduct = req.body;

    let product = await Product.findById(id);
    if (!product) {
        res.redirect(`error=${encodeURIComponent('Product was not found!')}`);
        return;
    }

    product.name = editedProduct.name;
    product.description = editedProduct.description;
    product.price = editedProduct.price;

    if (req.file) {
        product.image = path.normalize(path.join(req.file.destination, req.file.filename));
    }

    if (product.category.toString() !== editedProduct.category) {
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
}

module.exports.buyPost = (req, res) => {
    //TBA
}