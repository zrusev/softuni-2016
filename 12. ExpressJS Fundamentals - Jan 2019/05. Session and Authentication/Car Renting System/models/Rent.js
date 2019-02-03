const { Schema, model } = require('mongoose'); 

const rentSchema = new Schema({
    days: {
        type: Schema.Types.Number,
        required: true
    },
    car: {
        type: Schema.Types.ObjectId,
        required: true,
        ref: 'Car'
    },
    owner: {
        type: Schema.Types.ObjectId,
        required: true,
        ref: 'User'
    }
});

module.exports = model('Rent', rentSchema);