const fs = require('fs');
const formidable = require('formidable');
const path = require('path');
const shortid = require('shortid');
const db = require('../config/dataBase');

function viewAll(req, res) {
  fs.readFile('./views/viewAll.html', async (err, data) => {
    if (err) {
      console.log(err);
      return;
    }

    res.writeHead(200, {
      'Content-Type': 'text/html'
    });

    let memes = await db.load();
    let sortedMemes = memes.filter((meme) => meme.privacy !== undefined).sort((a, b) => b.dateStamp - a.dateStamp);

    let replacement = '';

    for (const meme of sortedMemes) {
      replacement += `<div class="meme">
      <a href="/getDetails?id=${meme.id}">
      <img class="memePoster" src="${meme.memeSrc}"/>          
      </div>`;
    }

    res.end(data.toString().replace('{{replaceMe}}', replacement));
  });
}

function getDetails(req, res) {
  fs.readFile('./views/details.html', async (err, data) => {
    if (err) {
      console.log(err);
      return;
    }

    res.writeHead(200, {
      'Content-Type': 'text/html'
    });

    let memeIndex = req.url.split('?id=')[1];

    let memes = await db.load();

    let targetedMeme = memes.find((meme) => meme.id === memeIndex);

    if (targetedMeme === undefined) {
      res.writeHead(404);
      res.end('Invalid meme id!');
    }

    let replacement = `<div class="content">
      <img src="${targetedMeme.memeSrc}" alt=""/>
      <h3>Title ${targetedMeme.title}</h3>
      <p> ${targetedMeme.description}</p>
      </div>`;

    res.end(data.toString().replace('{{replaceMe}}', replacement));
  });
}

function viewAddMeme(req, res) {
  fs.readFile('./views/addMeme.html', (err, data) => {
    if (err) {
      console.log(err);
      return;
    }

    res.writeHead(200, {
      'Content-Type': 'text/html'
    });

    res.end(data);
  });
}

function addMeme(req, res) {
  var form = new formidable.IncomingForm();
    form.parse(req, function (err, fields, files) {
      if (err) {
        console.log(err);

        res.writeHead(404, {
          'Content-Type': 'text/plain'
        });

        res.write('404 not found!');
        res.end();

        return;
      }

      if (!fields.memeTitle || !files.meme) {
        fs.readFile('./views/addMeme.html', (err, content) => {
          res.writeHead(200, {
            'Content-Type': 'text/html'
          });

          let resHtml = content.toString().replace('{{replaceMe}}', '<div id="errBox"><h2 id="errMsg">Please fill all required fields</h2></div>');

          res.write(resHtml);
          res.end();
        });
      } else {
        let oldpath = files.meme.path;
        let fileName = Math.random().toString(36).replace(/[^a-z]+/g, '').substr(0, 9) + '.jpg';
        let newpath = path.normalize(path.join(__dirname, '../public/memeStorage/'))  + fileName;
        
        fs.rename(oldpath, newpath, async function (err) {
          if (err) {
            console.log(err);
            return;
          }

          console.log('File uploaded and moved!');

          let meme = {
            id: shortid.generate(),
            title: fields.memeTitle,
            memeSrc: `./public/memeStorage/${fileName}`,
            description: fields.memeDescription,
            privacy: fields.status,
            dateStamp: files.meme.lastModifiedDate.valueOf()
          }

          let memes = await db.load();          
          memes.push(meme);
          
          await db.save();

          res.writeHead(302, { 'Location': '/viewAllMemes' });
          res.end();
        });
      }
    });
}

module.exports = (req, res) => {
  if (req.pathname === '/viewAllMemes' && req.method === 'GET') {
    viewAll(req, res);
  } else if (req.pathname === '/addMeme' && req.method === 'GET') {
    viewAddMeme(req, res);
  } else if (req.pathname === '/addMeme' && req.method === 'POST') {
    addMeme(req, res);
  } else if (req.pathname.startsWith('/getDetails') && req.method === 'GET') {
    getDetails(req, res);
  } else if (req.pathname.startsWith('public/memeStorage') && req.method === 'GET') {
    console.log('HERE');
  } else {
    return true;
  }
}