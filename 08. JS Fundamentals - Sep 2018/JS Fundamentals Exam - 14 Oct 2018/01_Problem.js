function coffeeMachine(input) {
  income = 0.0;

  let coffeeCaffeinePrice = 0.8;
  let coffeeDecafPrice = 0.9;
  let teaPrice = 0.8;

  let insertedCoins = 0.00;

  input.forEach((line) => {
    let data = line.split(', ');

    let suggar = +data.pop();

    insertedCoins = +data[0];
    let drinkType = data[1];
    let coffeeType;
    let milk;

    if (drinkType === "coffee") {
      coffeeType = data[2];
      milk = data[3];
    } else {
      milk = data[2];
    }

    let order = 0.0;
    let result = false;

    switch (drinkType) {
      case "coffee":
        if (coffeeType == "caffeine") {
          order = addMilkSugar(milk, coffeeCaffeinePrice, suggar);
          result = isEnough(insertedCoins, order);
          insertedCoins = printResult(result, drinkType, insertedCoins, order);
        } else {
          order = addMilkSugar(milk, coffeeDecafPrice, suggar);
          result = isEnough(insertedCoins, order);
          insertedCoins = printResult(result, drinkType, insertedCoins, order);
        }
        break;
      case "tea":
        order = addMilkSugar(milk, teaPrice, suggar);
        result = isEnough(insertedCoins, order);
        insertedCoins = printResult(result, drinkType, insertedCoins, order);
        break;
    }
  });

  console.log(`Income Report: ${income.toFixed(2)}$`);

  function addMilkSugar(milk, price, suggar) {
    let order = price;

    if (milk !== undefined) {
      order = price + +(price * 0.1).toFixed(1);
    }

    if (suggar > 0 && suggar <= 5) {
      order += 0.1;
    }

    return order;
  }

  function printResult(result, drinkType, insertedCoins, price) {
    let change = (insertedCoins - price) <= 0 ? '0.00' : (insertedCoins - price).toFixed(2);

    if (!result) {
      console.log(`Not enough money for ${drinkType}. Need ${Math.abs(insertedCoins - price).toFixed(2)}$ more.`);
      return insertedCoins;
    } else {
      console.log(`You ordered ${drinkType}. Price: ${price.toFixed(2)}$ Change: ${change}$`);
      income += price;
      return insertedCoins - price;
    }
  }

  function isEnough(insertedCoins, pricePerDrink) {
    return insertedCoins >= pricePerDrink;
  }
}

coffeeMachine(
  ['8.00, coffee, decaf, 4',
    '1.00, tea, 2'
  ]

)