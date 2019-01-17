const fs = require('fs');
const storageFile = './storage.json';

module.exports = {
    storage: {},
    put: function (key, value) {
        if (typeof key !== "string") {
            throw new Error('Invalid argument!');
        }

        if (!this.storage.hasOwnProperty(key)) {
            this.storage[key] = value;
        } else {
            throw new Error('Key already exists!');
        }

        return this;
    },
    get: function (key) {
        if (typeof key !== "string") {
            throw new Error('Invalid argument!');
        }

        if (this.storage.hasOwnProperty(key)) {
            return this.storage[key];
        } else {
            throw new Error('Key does not exist in the storage!');
        }
    },
    getAll: function () {
        if (isEmpty(this.storage)) {
            return 'There are no items in the storage!';
        }

        return this.storage;

        function isEmpty(obj) {
            for (var prop in obj) {
                if (obj.hasOwnProperty(prop))
                    return false;
            }

            return true;
        }
    },
    update: function (key, newValue) {
        if (typeof key !== "string") {
            throw new Error('Invalid argument!');
        }

        if (this.storage.hasOwnProperty(key)) {
            this.storage[key] = newValue;
        } else {
            throw new Error('Key does not exist in the storage!');
        }

        return this;
    },
    delete: function (key) {
        if (typeof key !== "string") {
            throw new Error('Invalid argument!');
        }

        if (!this.storage.hasOwnProperty(key)) {
            throw new Error('Key does not exist in the storage!');
        } else {
            delete this.storage[key];
        }

        return this;
    },
    clear: function () {
        this.storage = {};
        return this;
    },
    save: function () {
        if (fs.existsSync(storageFile)) {
            fs.truncateSync(storageFile, 0, function (err) {
                if (err) {
                    throw err;
                }
            });
        }

        fs.writeFileSync(storageFile, JSON.stringify(this.storage), 'utf8', function (err) {
            if (err) {
                throw err;
            }
        });

        return this;
    },
    load: function () {
        if (fs.existsSync(storageFile)) {
            let content = fs.readFileSync(storageFile, 'utf8', function (err) {
                if (err) {
                    throw err;
                }
            });

            if (content.length > 0) {
                this.storage = JSON.parse(content);
            }
        }

        return this;
    }
}