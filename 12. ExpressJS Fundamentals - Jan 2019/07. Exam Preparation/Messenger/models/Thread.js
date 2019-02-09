const mongoose = require('mongoose');
const Schema = require('mongoose').Schema;
const message = require('../common/message');

const threadSchema = new Schema({
    users: [{
        type: Schema.Types.ObjectId,
        ref: 'User',
        required: true
    }],
    dateCreated: {
        type: Schema.Types.Date,
        required: true,
        default: Date.now
    }
});

module.exports = mongoose.model('Thread', threadSchema);