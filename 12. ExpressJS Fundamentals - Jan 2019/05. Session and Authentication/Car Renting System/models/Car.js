const { Schema, model } = require('mongoose'); 

const carSchema = new Schema({
    model: {
        type: Schema.Types.String,
        required: true
    },
    image: {
        type: Schema.Types.String,
        required: true
    },
    pricePerDay: {
        type: Schema.Types.Number,
        required: true
    },
    isRented: {
        type: Schema.Types.Boolean,
        required: true,
        default: false
    }
});

module.exports = model('Car', carSchema);