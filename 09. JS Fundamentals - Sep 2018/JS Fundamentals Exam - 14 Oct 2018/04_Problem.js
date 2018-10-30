function solve(input) {
  let brands = {};

  input.forEach((line) => {
    let data = line.split(', ');
    let command = data[0];
    let brandName;
    let coffeeName;
    let expireDate;
    let quantity;

    switch (command) {
      case 'IN':
        brandName = data[1];
        coffeeName = data[2];
        expireDate = data[3];
        quantity = +data[4];

        //brandName
        if (!brands.hasOwnProperty(brandName)) {
          brands[brandName] = {}
        }

        //coffeeName
        if (!brands[brandName].hasOwnProperty(coffeeName)) {
          brands[brandName][coffeeName] = {};
        }

        //quantity
        if (!brands[brandName][coffeeName].hasOwnProperty("quantity")) {
          brands[brandName][coffeeName]["quantity"] = quantity;
        }

        //expireDate
        if (!brands[brandName][coffeeName].hasOwnProperty("expireDate")) {
          brands[brandName][coffeeName]["expireDate"] = expireDate;
        } else if (expireDate > brands[brandName][coffeeName]["expireDate"]) {
          brands[brandName][coffeeName]["expireDate"] = expireDate;
          brands[brandName][coffeeName]["quantity"] = quantity;
        } else if (brands[brandName][coffeeName]["expireDate"] === expireDate) {
          brands[brandName][coffeeName]["quantity"] += quantity;
        }

        break;
      case 'OUT':
        brandName = data[1];
        coffeeName = data[2];
        expireDate = data[3];
        quantity = +data[4];

        if (!brands[brandName]) {
          return;
        }

        if (!brands[brandName][coffeeName]) {
          return;
        }

        if (brands[brandName][coffeeName]["expireDate"] >= expireDate &&
          brands[brandName][coffeeName]["quantity"] >= quantity) {
          brands[brandName][coffeeName]["quantity"] -= quantity;

          if (brands[brandName][coffeeName]["quantity"] < 0) {
            brands[brandName][coffeeName]["quantity"] = 0;
          }
        }


        break;
      case 'REPORT':
        console.log('>>>>> REPORT! <<<<<');

        for (let nameOfBrand of Object.keys(brands)) {
          console.log(`Brand: ${nameOfBrand}:`);
          for (let coffee of Object.keys(brands[nameOfBrand])) {
            console.log(`-> ${coffee} -> ${brands[nameOfBrand][coffee]["expireDate"]} -> ${brands[nameOfBrand][coffee]["quantity"]}.`);
          }
        }
        break;
      case 'INSPECTION':
        let sorted = Object.entries(brands)
          .sort((a, b) => a - b);


        console.log('>>>>> INSPECTION! <<<<<');
        for (let brand of sorted) {
          console.log(`Brand: ${brand[0]}:`);

          let sortedCoffee = Object.entries(brand[1]).sort((a, b) => b[1]["quantity"] - a[1]["quantity"]);

          for (let coffee of sortedCoffee) {
            console.log(`-> ${coffee[0]} -> ${coffee[1]["expireDate"]} -> ${coffee[1]["quantity"]}.`);
          }
        }
        break;
    }
  });
}

solve([
  "IN, Batdorf & Bronson, Espresso, 2025-05-25, 20",
  "IN, Folgers, Black Silk, 2023-03-01, 14",
  "IN, Lavazza, Crema e Gusto, 2023-05-01, 5",
  "IN, Lavazza, Crema e Gusto, 2023-05-02, 5",
  "IN, Folgers, Black Silk, 2022-01-01, 10",
  "IN, Lavazza, Intenso, 2022-07-19, 20",
  "OUT, Dallmayr, Espresso, 2022-07-19, 5",
  "OUT, Dallmayr, Crema, 2022-07-19, 5",
  "OUT, Lavazza, Crema e Gusto, 2020-01-28, 2",
  "REPORT",
  "INSPECTION",
])