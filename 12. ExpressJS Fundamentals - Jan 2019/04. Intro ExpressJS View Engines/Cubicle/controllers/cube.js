const mongoose = require('mongoose');

module.exports = {
    createGet: (req, res) => {
        res.render('create');
    },
    createPost: (req, res) => {
        const { name, description, imageUrl, difficulty } = req.body;

        const model = new mongoose.models.CubeModel({
            name,
            description,
            imageUrl,
            difficulty
        });

        model.save()
            .then(() => {
                res.redirect('/');
            })
            .catch((err) => {
                //console.log(err.stack);
                res.render('create', { err: err.message });
            });
    },
    details: (req, res) => {
        const { id } = req.params;

        const query = mongoose.models.CubeModel.findById(id);

        query.exec((err, result) => {
            if (err) {
                throw err;
            }

            res.render('details', result);
        });
    }
}