const mongoose = require('mongoose');
mongoose.Promise = global.Promise;

module.exports = config => {
    mongoose.connect(config.dbPath, {
        useMongoClient: true
    });

    const db = mongoose.connection;

    db.once('open', (err, res) => {
        if (err) {
            throw err
        };

        require('../models/cubeModel')(mongoose);

        console.log("Connected to database and created the routes...");
    });

    db.on('error', reason => {
        console.log(reason);
    });
};