module.exports = mongoose => {
    const cubeModelSchema = new mongoose.Schema({
            name: {
                type: String,
                minlength: 3,
                maxlength: 15
            },
            description: {
                type: String,
                minlength: 20,
                maxlength: 300
            },
            imageUrl: {
                type: String,
                match: /^https:\/\/.*(.jpg|.png)$/
            },
            difficulty: {
                type: Number,
                min: 1,
                max: 6
            }
        })
        .post('save', function (error, doc, next) {
            const errType = Object.keys(error.errors)[0];

            if (errType === 'name') {
                next(new Error('Name must be between 3 and 15 symbols!'));
            } else if(errType === 'description') {
                next(new Error('Description must be between 20 and 300 symbols!'));    
            } else if(errType === 'imageUrl') {
                next(new Error('Image URL must start with "https://" and Image URL must end with ".jpg" or ".png"!'));    
            } else {
                next();
            }
        });

    mongoose.model('CubeModel', cubeModelSchema);
}