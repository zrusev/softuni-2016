const Schema = require('mongoose').Schema;
const mongoose = require('mongoose'); 

const articleSchema = new Schema({
    title: {
        type: Schema.Types.String,
        required: true,
        unique: true
    },
    content: {
        type: Schema.Types.String,
        required: true
    },
    author: {
        type: Schema.Types.ObjectId,
        ref: 'User'
    },
    date: {
        type: Schema.Types.Date,
        default: Date.now
    },
});

const Article = mongoose.model('Article', articleSchema);

module.exports = Article;