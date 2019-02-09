const path = require('path');

module.exports = {
    development: {
        rootFolder: path.normalize(path.join(__dirname, '/../')),
        port: process.env.PORT || 3000,
        dbPath: 'mongodb://localhost:27017/demo-server-db'
    },
    production: {}
};