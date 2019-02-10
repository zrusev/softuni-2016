module.exports = (err, res, view, obj) => {
    let errors = [];

    if (typeof err === 'string') {
        errors.push(err);
    } else if (err.message.includes('Wrong validation:')) {
        errors.push(err.message.replace(/Wrong validation:/, ''));
    } else {
        for (const prop in err.errors) {
            errors.push(err.errors[prop].message);
        }
    }

    res.locals.globalErrors = errors.reverse();
    res.render(view, obj);
}