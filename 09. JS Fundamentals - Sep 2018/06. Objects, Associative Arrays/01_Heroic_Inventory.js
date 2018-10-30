function heroes(input) {
  let heroes = input.map((line) => {
    let data = line.split(' / ');
    return {
      "name" : data[0],
      "level" : +data[1],
      "items" : data[2].split(', ')      
    }
  })

  console.log(JSON.stringify(heroes));
}

heroes(['Isacc / 25 / Apple, GravityGun',
'Derek / 12 / BarrelVest, DestructionSword',
'Hes / 1 / Desolator, Sentinel, Antara']
)