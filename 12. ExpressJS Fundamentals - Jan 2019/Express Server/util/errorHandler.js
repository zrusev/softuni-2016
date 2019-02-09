module.exports = (err, res, view, obj) => {
    let errors = [];

    if (typeof err === 'string') {
        errors.push(err);
    } else if (err.code === 11000) {
        errors.push('Username already taken. Please pick another!');
    } else {
        for (const prop in err.errors) {
            errors.push(err.errors[prop].message);
        }
    }

    res.locals.globalErrors = errors.reverse();
    res.render(view, obj);
}