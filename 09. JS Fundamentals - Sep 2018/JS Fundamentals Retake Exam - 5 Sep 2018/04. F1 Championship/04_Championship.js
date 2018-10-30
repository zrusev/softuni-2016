function championship(input) {
  let all = new Map();

  input.forEach((line) => {
    let data = line.split(' -> ');
    let team = data[0];
    let pilot = data[1];
    let points = +data[2];

    if (!all.has(team)) {
      all.set(team, new Map());
    }

    if (!all.get(team).has(pilot)) {
      all.get(team).set(pilot, points);
    } else {
      all.get(team).set(pilot, all.get(team).get(pilot) + points)
    }
  })

  let sortedAll = [...all].sort((a, b) => [...b[1].values()].reduce((a, b) => a + b) - [...a[1].values()].reduce((a, b) => a + b))
    .slice(0, 3);

  for (let [team, pilot] of sortedAll) {
    console.log(`${team}: ${[...pilot.values()].reduce((a,b) => a + b)}`);

    let sortedPilots = [...pilot].sort((a, b) => b[1] - a[1]);

    for (let [pilot, points] of sortedPilots) {
      console.log(`-- ${pilot} -> ${points}`);
    }
  }
}

championship(["Ferrari -> Kimi Raikonnen -> 25",
  "Ferrari -> Sebastian Vettel -> 18",
  "Mercedes -> Lewis Hamilton -> 10",
  "Mercedes -> Valteri Bottas -> 8",
  "Red Bull -> Max Verstapen -> 6",
  "Red Bull -> Daniel Ricciardo -> 4"
])