function kompot (input) {
  const peachWeigthInGr = 140;
  const peachesPerKompot = 2.5;
  const plumWeigthInGr = 20;
  const plumsPerKompot = 10;
  const cherryWeigthInGr = 9;
  const cherriesPerKompot = 25;
  const rakiyaGr = 0.2;

  let bucket = [];
  let splitter = [];

  let fruits = input.forEach((f) => {
    let data = f.split(/\s+/gm);
    let fruit = data[0];
    let quantity = +data[1];

    switch(fruit.toLowerCase()) {
      case "peach": splitter.push({"product" : "peach", "quantity" : quantity})
      break;
      case "plum": splitter.push({"product" :"plum", "quantity" : quantity})
      break;
      case "cherry": splitter.push({"product" :"cherry", "quantity" : quantity})
      break;
      default: bucket.push(quantity);
    }
  });
  
  let peachKompots = Math.floor(getTotalWeight(splitter, "peach") * 1000 / peachWeigthInGr / peachesPerKompot);

  let plumKompots = Math.floor(getTotalWeight(splitter, "plum") * 1000 / plumWeigthInGr / plumsPerKompot);
  
  let cherryKompots = Math.floor(getTotalWeight(splitter, "cherry") * 1000 / cherryWeigthInGr / cherriesPerKompot);
 
  console.log(`Cherry kompots: ${cherryKompots}`);
  console.log(`Peach kompots: ${peachKompots}`);
  console.log(`Plum kompots: ${plumKompots}`);
  
  let quantityInBucket = bucket.reduce((acc, cur) => acc + cur, 0);

  console.log(`Rakiya liters: ${(quantityInBucket * rakiyaGr).toFixed(2)}`);

  function getTotalWeight(splitter, fruit) {
    let total = splitter
      .filter((f) => f.product === fruit)
      .reduce((acc, fr) => {
        return acc + fr.quantity;
      }, 0);

      return total;
  }
}

kompot([   'apple 6',
'peach 25.158',
'strawberry 0.200',
'peach 0.1',
'banana 1.55',
'cherry 20.5',
'banana 16.8',
'grapes 205.65'
,'watermelon 20.54'
]

)