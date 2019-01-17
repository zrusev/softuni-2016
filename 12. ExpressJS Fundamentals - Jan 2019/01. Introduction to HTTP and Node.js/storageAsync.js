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
                if (obj.hasOwnProperty(prop)) {
                    return false;
                }
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
    save: async function () {
        await fs.writeFile(storageFile, JSON.stringify(this.storage), 'utf8', function (err) {
            if (err) {
                throw err;
            }
        });
    },
    load: async function () {
        let that = this;

        return await new Promise(function (resolve, reject) {
            fs.readFile(storageFile, 'utf8', function (err, data) {
                if (err) {
                    // if the storage.json file does not exist create it
                    fs.writeFile(storageFile, '', 'utf8', function (err) {
                        if (err) {
                            throw err;
                        }

                        // create and resolve the promise
                        resolve(that);
                    });
                } else {
                    if (data.length > 0) {
                        that.storage = JSON.parse(data);
                        resolve(that);
                    } else {
                        // resolve it in case of an empty storage.json file
                        resolve(that);
                    }
                }
            });                
        });
    }
}