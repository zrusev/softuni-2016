function juiceCounter (input) {
   let juice = {}; 
   let bottles = [];
   
   input.forEach((line) => {
    let data = line.split(' => ');
    let fruit = data[0];
    let quantity = +data[1];

    if(!juice[fruit]) {
      juice[fruit] = quantity
    } else {
      juice[fruit] += quantity;
    }
    
    if (juice[fruit] >= 1000 && !Object.values(bottles).find((d) => d === fruit)) {
      bottles.push(fruit); 
    }
  });
  
  for(let fruit in bottles) {
    console.log(`${bottles[fruit]} => ${parseInt(juice[bottles[fruit]] / 1000)}`);
  }
}

juiceCounter(
  ['Orange => 2000',
  'Peach => 1432',
  'Banana => 450',
  'Peach => 600',
  'Strawberry => 549']
)