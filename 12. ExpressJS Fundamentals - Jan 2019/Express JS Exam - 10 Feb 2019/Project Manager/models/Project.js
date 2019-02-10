const mongoose = require('mongoose');
const Schema = mongoose.Schema;
const message = require('../common/message');

const projectSchema = new mongoose.Schema({
        name: {
            type: Schema.Types.String,
            required: [true, message.requiredProjectName],
            unique: true
        },
        description: {
            type: Schema.Types.String,
            required: [true, message.requiredDescription],
            // maxlength: 50, //custom validation within the custom errorHandler
            validate: {
                validator: function (v) {
                    return v.length <= 50;
                },
                message: message.maxLengthDescription
            },
        },
        team: {
            type: Schema.Types.ObjectId,
            ref: 'Team'
        }
    })
    .post('save', function (err, doc, next) {
        if (err.name === 'MongoError' && err.code === 11000) {
            next(new Error('Wrong validation:' + message.duplicateProjectname));
        }
        next();
    });

const Project = mongoose.model('Project', projectSchema);

module.exports = Project;