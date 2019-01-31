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
            const errObject = {
                name: 'Name must be between 3 and 15 symbols!',
                description: 'Description must be between 20 and 300 symbols!',
                imageUrl: 'Image URL must start with "https://" and Image URL must end with ".jpg" or ".png"!'
            }
            
            //Display multiple errors at once            
            //let errors = [];
            //
            //for (const prop in error.errors) {
            //    errors.push(errObject[prop]);
            //}
            //
            //next(new Error(errors.join('\n')));
            
            //Display single error at a time
            const errType = Object.keys(error.errors)[0];
            
            if (errObject.hasOwnProperty(errType)) {                
                next(new Error(errObject[errType]));
            } else {
                next();
            }
        });

    mongoose.model('CubeModel', cubeModelSchema);
}