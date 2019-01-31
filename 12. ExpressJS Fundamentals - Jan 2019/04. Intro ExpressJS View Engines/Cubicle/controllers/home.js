const mongoose = require('mongoose');

module.exports = {
    homeGet: (req, res) => {
        const query = mongoose.models.CubeModel.find({});
        query.limit(20);

        query.exec((err, results) => {
            if (err) {
                throw err;
            }

            res.render('index', {
                cubes: results
            });
        });
    },
    about: (req, res) => {
        res.render('about');
    },
    search: (req, res) => {
        const { search, from, to } = req.query;
        const fromQuery = parseInt(from);
        const toQuery = parseInt(to);

        if (fromQuery < 1 || fromQuery > 6 || toQuery < 1 || toQuery > 6) {
            res.render('index', { err: 'The difficulty inputs must contain only numbers between 1 and 6!' });
            return;
        }

        const query = mongoose.models.CubeModel
            .find({
                $or: [{name: new RegExp(search, 'i')}, {description: new RegExp(search, 'i')}],
                difficulty: { $gte: isNaN(fromQuery) ? 1 : fromQuery, $lte: isNaN(toQuery) ? 6 : toQuery }
            })
            .limit(20);

        query.exec((err, results) => {
            if (err) {
                throw err;
            }

            res.render('index', { 
                cubes: results 
            });
        });            
    } 
}