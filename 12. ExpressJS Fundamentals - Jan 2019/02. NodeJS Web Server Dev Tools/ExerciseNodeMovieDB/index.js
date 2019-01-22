const http = require('http');
const handlers = require('./handlers');
const statusHandler = require('./handlers/status')

const port = 5000;

http
    .createServer(function (req, res) {
        try {
            if (req.headers['statusheader'] === 'Full') {
                statusHandler(req, res);
            } else {
                handlers.forEach(handler => {
                    if (!handler(req, res)) return;
                });
            }
        } catch (e) {
            res.writeHead(500);
            res.end();

            console.log(e.stack);
        }
    })
    .listen(port);

console.log("listening on port " + port);