const http = require('http');
const url = require('url');
const fs = require('fs');
const path = require('path');
const handlers = require('./handlers');
const baseDirectory = __dirname;

const port = 5000;

http
    .createServer(function (req, res) {
        try {
            // let reqUrl = url.parse(req.url);

            // need to use path.normalize so people can't access directories underneath baseDirectory
            // let fsPath = baseDirectory + path.normalize(reqUrl.pathname);

            handlers.forEach(handler => {
                if (!handler(req, res)) return;
            });

            // let fileStream = fs.createReadStream(fsPath);

            // fileStream.pipe(res);

            // fileStream.on('open', function () {
            //     res.writeHead(200);
            // });

            // fileStream.on('error', function (e) {
            //     res.writeHead(404);

            //     res.end();
            // });
        } catch (e) {
            res.writeHead(500);

            res.end();

            console.log(e.stack);
        }
    })
    .listen(port);

console.log("listening on port " + port);