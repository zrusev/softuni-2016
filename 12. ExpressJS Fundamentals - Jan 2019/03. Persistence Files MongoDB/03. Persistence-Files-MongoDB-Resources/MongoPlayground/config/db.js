const mongoose = require('mongoose');
const connString = 'mongodb://localhost:27017/mongoplayground';

module.exports = mongoose.connect(connString, { useNewUrlParser: true });