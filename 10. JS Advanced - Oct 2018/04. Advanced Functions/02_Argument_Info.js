function solve() {
  let summary = {};
  
  for (let i = 0; i < arguments.length; i++) {
    let obj  = arguments[i];
    let type = typeof obj;
    console.log(type + ": " + obj);
  
    if (!summary[type]) {
      summary[type] = 1;
    } else {
      summary[type]++;
    }  
  }

  let sortedTypes = [];
  for(let cur in summary) {
    sortedTypes.push([cur, summary[cur]]);
  }
  
  sortedTypes.sort((a, b) => b[1] - a[1]).forEach((el) => console.log(`${el[0]} = ${el[1]}`));
}

solve('cat', 42, function () { console.log('Hello world!'); });