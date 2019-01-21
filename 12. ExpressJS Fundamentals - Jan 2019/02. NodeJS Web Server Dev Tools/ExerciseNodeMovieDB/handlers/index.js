const homeHandler = require('./home');
const faviconHandler = require('./favicon');
const staticFilesHandler = require('./static-files');
const viewAllHandler = require('./viewAll');
const addMovieGet = require('./addMovieGet');
const addMoviePost = require('./addMoviePost');

module.exports = [ homeHandler, 
                   faviconHandler,
                   staticFilesHandler,
                   viewAllHandler,
                   addMovieGet,
                   addMoviePost
                 ];