function storeCatalogue (input) {
  let all = {};

  input.forEach((line) => {
    let data = line.split(' : ');
    
    let thing = data[0];
    let val = +data[1];
    
    all[thing] = val;    
  })

  let ordered = {};
  Object.keys(all).sort().forEach(function(key) {
    ordered[key] = all[key];
  });

  let container = '';
  for(let item of Object.keys(ordered)) {
    let firstLetter = item.charAt(0);

    if(firstLetter !== container) {
      console.log(firstLetter);
      container = firstLetter;
    }
    console.log(`  ${item}: ${ordered[item]}`)
  }
}

storeCatalogue(['Banana : 2',
'Rubic\'s Cube : 5',
'Raspberry P : 4999',
'Rolex : 100000',
'Rollon : 10',
'Rali Car : 2000000',
'Pesho : 0.000001',
'Barrel : 10']

)