const url = require('url');
const fs = require('fs');
const path = require('path');
const movies = require('../config/dataBase');

module.exports = (req, res) => {
    req.pathname = req.pathname || url.parse(req.url).pathname;

    if (req.pathname === '/viewAllMovies' && req.method === 'GET') {
        let filePath = path.normalize(path.join(__dirname, '../views/viewAll.html'));

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

            let allMoviesHtml = '';
            for (const movie of movies) {
                let movieHtml = '<div class="movie">';
                movieHtml += `<img class="moviePoster" src="${movie.moviePoster}" />`;
                movieHtml += '</div>';
                allMoviesHtml += movieHtml;
            }

            let resHtml = data.toString().replace('<div id="replaceMe">{{replaceMe}}</div>', allMoviesHtml);

            res.write(resHtml);
            res.end();
        })
    } else {
        return true;
    }
}