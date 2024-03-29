const mongoose = require('mongoose');
const encryption = require('../util/encryption');

const userSchema = new mongoose.Schema({
    username: {
        type: mongoose.Schema.Types.String,
        required: true,
        unique: true
    },
    hashedPass: {
        type: mongoose.Schema.Types.String,
        required: true
    },
    firstName: {
        type: mongoose.Schema.Types.String
    },
    lastName: {
        type: mongoose.Schema.Types.String
    },
    salt: {
        type: mongoose.Schema.Types.String,
        required: true
    },
    roles: [{
        type: mongoose.Schema.Types.String
    }]
});

userSchema.method({
    authenticate: function (password) {
        return encryption.generateHashedPassword(this.salt, password) === this.hashedPass;
    }
});

const User = mongoose.model('User', userSchema);

User.seedAdmin = async () => {
    try {
        let users = await User.find({});

        if (users.length > 0) {
            return;
        }

        const salt = encryption.generateSalt();
        const password = encryption.generateHashedPassword(salt, 'Admin13');

        return User.create({
            username: 'admin',
            hashedPass: password,
            firstName: 'Admin',
            lastName: 'Admin',
            salt: salt,
            roles: ['Admin']
        });
    } catch (error) {
        console.log(error);
    }
}

module.exports = User;