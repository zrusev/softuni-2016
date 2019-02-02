const Category = require('../models/Category');

module.exports.addGet = (req, res) => {
    res.render('category/add');
}

module.exports.productByCategory = (req, res) => {
    let categoryName = req.params.category;

    Category.findOne({
            name: categoryName
        })
        .populate('products')
        .then((category) => {
            if (!category) {
                res.sendStatus(404);
                return;
            }

            let products = category.products.filter(p => p.buyer === undefined);
            category.products = products;

            res.render('category/products', {
                category: category
            });
        });
}