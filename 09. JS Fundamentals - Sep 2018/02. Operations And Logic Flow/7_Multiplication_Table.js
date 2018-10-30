function multiplicationTable (n) {
  let fs = require('fs');
  let html = [];

  html.push('<table border="1"><tr><th>x</th>');

  for(let rw = 1; rw <= +n; rw++) {
    html.push(`<th>${rw}</th>`);
  }

  html.push('</tr>');

  for(let row = 1; row <= +n; row++) {
    html.push(`<tr><th>${row}</th>`);

    for(let col = 1; col <= +n; col++) {
      html.push(`<td>${row * col}</td>`);
    }
    
    html.push('</tr>');
  }

  html.push('</table>');
    
  fs.writeFile('7_table.html', html.join(), function(err) {
     if(err) {
         return console.log(err);
     }
   })
}

multiplicationTable(3);