const mongoose = require('mongoose');
const encryption = require('../util/encryption');
const message = require('../common/message');

const userSchema = new mongoose.Schema({
        username: {
            type: mongoose.Schema.Types.String,
            required: [true, message.requiredUsername],
            unique: true
        },
        hashedPass: {
            type: mongoose.Schema.Types.String,
            required: true,
            validate: {
                validator: function (v) {
                    const emptyPassword = encryption.generateHashedPassword(this.salt, '');
                    return this.hashedPass !== emptyPassword;
                },
                message: message.requiredPassword
            },
        },
        firstName: {
            type: mongoose.Schema.Types.String,
            required: [true, message.requiredFirstName]
        },
        lastName: {
            type: mongoose.Schema.Types.String,
            required: [true, message.requiredLastName]
        },
        teams: [{
            type: mongoose.Schema.Types.ObjectId,
            ref: 'Team'
        }],
        profilePicture: {
            type: mongoose.Schema.Types.String,
            default: 'https://themes.gohugo.io/theme/hugo-geo/img/profile.png'
        },
        salt: {
            type: mongoose.Schema.Types.String,
            required: true
        },
        roles: [{
            type: mongoose.Schema.Types.String,
            enum: ['User', 'Admin']
        }]
    })
    .post('save', function (err, doc, next) {
        if (err.name === 'MongoError' && err.code === 11000) {
            next(new Error('Wrong validation:' + message.duplicateUsername));
        }
        next();
    });

userSchema.method({
    authenticate: function (password) {
        return encryption.generateHashedPassword(this.salt, password) === this.hashedPass;
    },
    isInRole: function (role) {
        return this.roles.indexOf(role) !== -1;
    }
    // isAuthor: function (article) {
    //     if (!article) {
    //         return false;
    //     }
    //     let isAuthor = article.author.equals(this.id);
    //     return isAuthor;
    // }
});

userSchema.methods.comparePassword = function (candidatePassword, cb) {
    bcrypt.compare(candidatePassword, this.password, function (err, isMatch) {
        if (err) return cb(err);
        cb(null, isMatch);
    });
};

const User = mongoose.model('User', userSchema);

User.seedAdminUser = async () => {
    try {
        let users = await User.find();
        if (users.length > 0) return;

        const salt = encryption.generateSalt();
        const hashedPass = encryption.generateHashedPassword(salt, 'admin');

        return User.create({
            username: 'admin',
            firstName: 'Admin',
            lastName: 'Admin',
            salt,
            hashedPass,
            roles: ['Admin']
        });
    } catch (err) {
        console.log(err);
    }
};

module.exports = User;