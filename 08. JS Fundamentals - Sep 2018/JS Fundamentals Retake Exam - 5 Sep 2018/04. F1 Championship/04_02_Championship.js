function championship(input) {
  let all = {};

  input.forEach((line) => {
    let data = line.split(' -> ');
    let team = data[0];
    let pilot = data[1];
    let points = +data[2];

    if (!all.hasOwnProperty(team)) {
      all[team] = {
        "totalPoints": 0,
        "pilots": {}
      }
    }

    if (!all[team]["pilots"].hasOwnProperty(pilot)) {
      all[team]["pilots"][pilot] = 0;
    }

    all[team]["pilots"][pilot] += points;
    all[team]["totalPoints"] += points;
  })

  let winners = Object.entries(all)
    .sort((a, b) => b[1]["totalPoints"] - a[1]["totalPoints"])
    .slice(0, 3);

  for (let winnerTeam of winners) {
    console.log(`${winnerTeam[0]}: ${winnerTeam[1]["totalPoints"]}`);

    let sortedPilots = Object.entries(winnerTeam[1]["pilots"]).sort((a, b) => b[1] - a[1]);
    for (let pilot of sortedPilots) {
      console.log(`-- ${pilot[0]} -> ${pilot[1]}`);
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