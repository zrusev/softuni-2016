const mongoose = require('mongoose');
const Schema = mongoose.Schema;
const message = require('../common/message');

const teamSchema = new mongoose.Schema({
        name: {
            type: Schema.Types.String,
            required: [true, message.requiredTeamName],
            unique: true
        },
        projects: [{
            type: Schema.Types.ObjectId,
            ref: 'Project'
        }],
        members: [{
            type: Schema.Types.ObjectId,
            ref: 'User'
        }]
    })
    .post('save', function (err, doc, next) {
        if (err.name === 'MongoError' && err.code === 11000) {
            next(new Error('Wrong validation:' + message.duplicateTeamname));
        }
        next();
    });

const Team = mongoose.model('Team', teamSchema);

module.exports = Team;