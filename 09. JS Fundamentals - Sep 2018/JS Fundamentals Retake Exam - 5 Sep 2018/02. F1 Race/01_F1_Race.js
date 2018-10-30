function race (input) {
  let race = input[0].split(' ');
  
  for (let i = 1; i < input.length; i++) {
    let [action, racer] = input[i].split(' ');
    let currentIndex;

    switch(action.toLowerCase()) {
      case "join": 
      if(race.indexOf(racer) === -1) {
          race.push(racer);
        } 
      break;
      case "crash":
        if(race.indexOf(racer) > -1) {
          race.splice(race.indexOf(racer), 1);
        }  
      break;
      case "pit":
        currentIndex = race.indexOf(racer);
        array_move(race, currentIndex, currentIndex + 1)
      break;
      case "overtake": 
        currentIndex = race.indexOf(racer);
        array_move(race, currentIndex, currentIndex - 1)
      break;
    }    
  }

  console.log(race.join(' ~ '));    

  function array_move(arr, old_index, new_index) {
    if (new_index >= arr.length) {
        var k = new_index - arr.length + 1;
        while (k--) {
            arr.push(undefined);
        }
    }
    arr.splice(new_index, 0, arr.splice(old_index, 1)[0]);
    return arr;
  };
}

race(["Vetel Hamilton Raikonnen Botas Slavi",
"Pit Hamilton",
"Overtake LeClerc",
"Join Ricardo",
"Crash Botas",
"Overtake Ricardo",
"Overtake Ricardo",
"Overtake Ricardo",
"Crash Slavi"]
)