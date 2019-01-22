const url = require('url');
const fs = require('fs');
const path = require('path');
const qs = require('querystring');
const movies = require('../config/dataBase');

module.exports = (req, res) => {
    req.pathname = req.pathname || url.parse(req.url).pathname;

    if (req.pathname === '/addMovie' && req.method === 'POST') {
        let data = '';

        req.on('data', (chunk) => {
            data += chunk;
        });

        req.on('end', () => {
            let movie = qs.parse(data);

            if(!movie.movieTitle || !movie.moviePoster){
                let filePath = path.normalize(path.join(__dirname, '../views/addMovie.html'));

                fs.readFile(filePath, (err, content) => {
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

                    let resHtml = content.toString().replace('{{replaceMe}}', '<div id="errBox"><h2 id="errMsg">Please fill all fields</h2></div>');
                
                    res.write(resHtml);
                    res.end();

                    return;
                });

              } else {
                movies.push(movie);
                // ToDo: write all movies to file if needed
                res.writeHead(302, { 'Location': '/viewAllMovies' });
                res.end();
              }
        });
    } else {
        return true;
    }
}