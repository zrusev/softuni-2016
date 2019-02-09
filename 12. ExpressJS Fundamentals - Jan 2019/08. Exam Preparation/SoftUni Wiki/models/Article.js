const mongoose = require('mongoose');

const articleSchema = new mongoose.Schema({
    title: {
        type: mongoose.Schema.Types.String,
        required: true
    },
    lockedStatus: {
        type: mongoose.Schema.Types.Boolean,
        default: false
    },
    edits: [{
        type: mongoose.Schema.Types.ObjectId,
        ref: 'Edit'
    }]
});

const Article = mongoose.model('Article', articleSchema);

module.exports = Article;