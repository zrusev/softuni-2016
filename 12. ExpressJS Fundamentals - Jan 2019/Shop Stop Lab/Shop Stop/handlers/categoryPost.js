const Category = require('../models/Category');

module.exports.addPost = async (req, res) => {
    let category = req.body;
    
    Category.create(category).then(() => {
        res.redirect('/');
    });
}