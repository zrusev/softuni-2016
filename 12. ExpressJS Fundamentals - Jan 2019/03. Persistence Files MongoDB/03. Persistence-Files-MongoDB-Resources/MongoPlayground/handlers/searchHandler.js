const formidable = require('formidable');
const mongoose = require('mongoose');
const Image = require('../models/ImageSchema');
const fs = require('fs');

function searchTags(req, res) {
  const form = new formidable.IncomingForm();

  form.parse(req, function (err, fields, files) {
    if (err) {
      throw err;
    }

    const tagsToSearch = fields.tagName.split(',').reduce((p, c, i, a) => {
      if (p.includes(c) || c.length === 0) {
        return p;
      } else {
        p.push(c.trim());
        return p;
      }
    }, []);

    const postedAfter = fields.afterDate === '' ? new Date(1900, 1, 1) : fields.afterDate;
    const postedBefore = fields.beforeDate === '' ? new Date(2020, 1, 1) : fields.beforeDate;
    const limitQuery = fields.limit === '' ? 10 : Number(fields.limit);

    Image
      .find({
        'creationDate': {
          '$gte': postedAfter,
          '$lt': postedBefore
        }
      })
      //.limit(limitQuery)
      .populate('tags')
      .exec((err, results) => {
        if (err) {
          throw err;
        }

        let filtered = [];
        if (tagsToSearch.length > 0) {
          filtered = results
            .filter((t) => t.tags.some((f) => tagsToSearch.includes(f.name)))
            .slice(0, limitQuery)
            .sort((a,b) => b.creationDate - a.creationDate);          
        } else {
          filtered = results
            .slice(0, limitQuery);
        }

        fs.readFile('./views/results.html', (err, data) => {
          if (err) {
            throw err;
          }

          res.writeHead(200, {
            'Content-Type': 'text/html'
          });

          let container = '';
          for (const image of filtered) {
            container += `<fieldset id => <legend>${image.title}:</legend> 
            <img src="${image.url}">
            </img><p>${image.description}<p/>
            <button onclick='location.href="/delete?id=${image._id}"'class='deleteBtn'>Delete
            </button> 
            </fieldset>`;
          }

          res.end(data.toString().replace('<div class="replaceMe"></div>', container));
        });
      });
  });
}

module.exports = (req, res) => {
  if (req.pathname === '/search' && req.method === 'POST') {
    searchTags(req, res);
  } else {
    return true;
  }
}