const mongoose = require('mongoose');
const Schema = require('mongoose').Schema;

const messageSchema = new Schema({
    content: {
        type: Schema.Types.String,
        required: true
    },
    user: {
        type: Schema.Types.ObjectId,
        ref: 'User',
        required: true
    },
    thread: {
        type: Schema.Types.ObjectId,
        ref: 'Thread',
        required: true
    }
});

const Message = mongoose.model('Message', messageSchema);
module.exports = Message;