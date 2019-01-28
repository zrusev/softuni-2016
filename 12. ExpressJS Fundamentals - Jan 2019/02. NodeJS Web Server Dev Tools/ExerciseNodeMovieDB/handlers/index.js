const homeHandler = require('./home');
const faviconHandler = require('./favicon');
const staticFilesHandler = require('./static-files');
const viewAllHandler = require('./viewAll');
const addMovieGetHandler = require('./addMovieGet');
const addMoviePostHandler = require('./addMoviePost');
const detailsHandler = require('./details');
const statusHandler = require('./details');

module.exports = [ homeHandler, 
                   faviconHandler,
                   staticFilesHandler,
                   viewAllHandler,
                   addMovieGetHandler,
                   addMoviePostHandler,
                   detailsHandler,
                   statusHandler
                 ];