const car = {
  model: 'VW Golf II',
  power: 90,
  color: 'blue',
  carriage: 'hatchback',
  wheelsize: 14
}

function solve(obj) {
  let current = {};

  current.model = obj.model;

  let engine = {};

  if (obj.power <= 90) {
    engine = {
      power: 90,
      volume: 1800
    }
  } else if (obj.power <= 120) {
    engine = {
      power: 120,
      volume: 2400
    }
  } else if (obj.power <= 200) {
    engine = {
      power: 200,
      volume: 3500
    }
  }

  current.engine = engine;

  current.carriage = {
    type: obj.carriage,
    color: obj.color
  }

  if (obj.wheelsize % 2 === 0) {
    obj.wheelsize--;
  }

  let wheels = [];

  for (let i = 0; i < 4; i++) {
    wheels.push(obj.wheelsize);  
  }

  current.wheels = wheels;

  return current;
}

solve(car);