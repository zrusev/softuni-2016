function jsonTable(input) {
  let result = input.map((line) => {
    return JSON.parse(line);
  }) 

  console.log('<table>');
  
  for(let item of result) {
    console.log(` <tr>`);

    console.log(`<td>${item.name}</td>`);
    console.log(`<td>${item.position}</td>`);
    console.log(`<td>${item.salary}</td>`);
    
    console.log(` </tr>`);
  }
  
  console.log('</table>');
}

jsonTable(['{"name":"Pesho","position":"Promenliva","salary":100000}',
'{"name":"Teo","position":"Lecturer","salary":1000}',
'{"name":"Georgi","position":"Lecturer","salary":1000}']
)