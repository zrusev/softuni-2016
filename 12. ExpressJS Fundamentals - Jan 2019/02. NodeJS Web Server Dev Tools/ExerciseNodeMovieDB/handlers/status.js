const url = require('url');
const fs = require('fs');
const path = require('path');
const movies = require('../config/dataBase');

module.exports = (req, res) => {
    req.pathName = req.pathname || url.parse(req.url).pathname;

    if (req.pathName === '/' && req.method === 'GET') {
        let filePath = path.normalize(path.join(__dirname, '../views/status.html'));

        fs.readFile(filePath, (err, data) => {
            if (err) {
                console.log(err);
                res.writeHead(404, {
                    'Content-Type': 'text/plain'
                });

                res.write('404 not found!');
                res.end();
                return;
            }

            res.writeHead(200, {
                'Content-Type': 'text/html'
            });

            data = data.replace('{{replaceMe}}', 'Total number of movies: ' + movies.length);

            res.write(data);
            res.end();
        });
    } else {
        return true;
    }
}