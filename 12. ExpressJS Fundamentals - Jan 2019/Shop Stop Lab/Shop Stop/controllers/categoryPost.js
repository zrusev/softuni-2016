const Category = require('../models/Category');

module.exports.addPost = async (req, res) => {
    let category = req.body;
    category.creator = req.user._id;
    
    Category.create(category).then(() => {
        res.redirect('/');
    });
}