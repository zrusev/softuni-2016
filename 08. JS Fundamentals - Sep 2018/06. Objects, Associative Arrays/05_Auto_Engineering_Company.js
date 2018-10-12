function autoCompany(input) {
  let brands = {};

  input.forEach((line) => {
    let data = line.split(' | ');
    let currentBrand = data[0];
    let currentModel = data[1];
    let currentCount = +data[2];

    let model = {
      [currentModel] : currentCount
    }

    if(!brands.hasOwnProperty(currentBrand)) {
      brands[currentBrand] = model;
    } else if (brands[currentBrand][currentModel] === undefined){
      brands[currentBrand][currentModel] = currentCount;
    } else {
      brands[currentBrand][currentModel] += currentCount;
    }
  })

  for(let br of Object.keys(brands)) {
    console.log(`${br}`);
    for(let mod of Object.keys(brands[br])) {
      console.log(`###${mod} -> ${brands[br][mod]}`);
    }
  }
}

autoCompany(['Audi | Q7 | 1000',
'Audi | Q6 | 100',
'BMW | X5 | 1000',
'BMW | X6 | 100',
'Citroen | C4 | 123',
'Volga | GAZ-24 | 1000000',
'Lada | Niva | 1000000',
'Lada | Jigula | 1000000',
'Citroen | C4 | 22',
'Citroen | C5 | 10']
)