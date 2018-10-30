function userNames (input) {
  let catalogue = new Set();
  input.forEach((name) => catalogue.add(name));

  let sorted = Array.from(catalogue)
    .sort((a,b) => a.length - b.length || a.localeCompare(b));

  console.log(sorted.join('\n'));
}

userNames(['Denise',
'Ignatius',
'Iris',
'Isacc',
'Indie',
'Dean',
'Donatello',
'Enfuego',
'Benjamin',
'Biser',
'Bounty',
'Renard',
'Rot']
)