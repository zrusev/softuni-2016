const fs = require('fs');
const path = require('path');
// const dbPath = path.join(__dirname, '/database.json');
const database = require('../config/dataBase');

function getMovies () {
    // if (fs.existsSync(dbPath)) {
    //     fs.writeFileSync(dbPath, '[]');
    //     return [];
    // }

    // let json = fs.readFileSync(dbPath).toString() || '[]';
    // let movies = JSON.parse(json);
    // return movies;

    return database;
}

// function saveMovies(movie) {
//     let json = JSON.stringify(movie);
//     fs.writeFileSync(dbPath, json);
// }

let movies = {};

module.exports.movies = {};

module.exports.movies.getAll = getMovies();

// module.exports.movies.add = (movie) => {
//     let movies = getMovies();
//     movie.id = movie.length + 1;
//     movies.push(movie);
//     //save to databse;
// }

// module.exports.movies.findByName = (name) => {
//     return getMovies().filter(m => m.movieTitle.toLowerCase().includes(name));
// }