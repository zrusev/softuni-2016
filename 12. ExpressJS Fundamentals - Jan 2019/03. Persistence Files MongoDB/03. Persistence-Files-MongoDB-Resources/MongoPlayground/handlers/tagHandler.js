const Tag = require('mongoose').model('Tag');
const formidable = require('formidable');

module.exports = (req, res) => {
  if (req.pathname === '/generateTag' && req.method === 'POST') {
    const form = new formidable.IncomingForm();

    form.parse(req, function (err, fields, files) {
      if (err) {
        throw err;
      }

      res.writeHead(200, {
        'content-type': 'text/plain'
      });

      const name = fields.tagName;

      Tag.create({
        name,
        images: []
      }).then(() => {
        res.writeHead(302, {
          location: '/'
        });
        res.end();
      }).catch(() => {
        res.writeHead(500, {
          'content-type': 'text/plain'
        });
        res.write('500 server error');
        res.end();
      });
    });

  } else {
    return true;
  }
}