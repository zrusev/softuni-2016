function solve(input, info) {
  let passangerWithTwoNamesPattern = /\s[A-Z][a-z]*-[A-Z][a-z]*\s/g;
  let passangerWithThreeNamesPattern = /\s[A-Z][a-z]*-[A-Z][a-z]*\.-[A-Z][a-z]*\s/g;
  //let nameRegex = / [A-Z]\w*-([A-Z]\w*\.-)?[A-Z]\w* /;

  let airportPattern = /\s[A-Z]{3}\/[A-Z]{3}\s/g;
  let flightPattern = /\s[A-Z]{1,3}\d{1,5}\s/g;
  let companyPattern = /\-\s[A-Z][A-Za-z]*\*[A-Z][A-Za-z]*\s/g;

  let name = input.match(passangerWithTwoNamesPattern) || input.match(passangerWithThreeNamesPattern);

  if (name !== null) {
    name = name[0].replace(/\s/g, '').replace(/-/g, ' ');
  }

  let airport = input.match(airportPattern);
  let fromAirport;
  let toAirport;

  if (airport !== null) {
    airport = airport[0].replace(/\s/g, '').split('/');
    fromAirport = airport[0];
    toAirport = airport[1];
  }

  let flightNumber = input.match(flightPattern);
  if (flightNumber !== null) {
    flightNumber = flightNumber[0].replace(/\s/g, '');
  }

  let company = input.match(companyPattern);
  if (company !== null) {
    company = company[0].replace(/-/g, '').replace(/\s/g, '').replace(/\*/g, ' ');
  }

  switch (info.toLowerCase()) {
    case "name":
      console.log(`Mr/Ms, ${name}, have a nice flight!`);
      break;
    case "flight":
      console.log(`Your flight number ${flightNumber} is from ${fromAirport} to ${toAirport}.`);
      break;
    case "company":
      console.log(`Have a nice flight with ${company}.`);
      break;
    case "all":
      console.log(`Mr/Ms, ${name}, your flight number ${flightNumber} is from ${fromAirport} to ${toAirport}. Have a nice flight with ${company}.`);
      break;
  }

}

solve('ahah Second-Testov )*))&&ba SOF/VAR ela** FB973 - Bulgaria*Air -opFB900 pa-SOF/VAr//_- T12G12 STD08:45  STA09:35 ', 'name')
solve('ahah Second-Testov )*))&&ba SOF/VAR ela** FB973 - Bulgaria*Air -opFB900 pa-SOF/VAr//_- T12G12 STD08:45  STA09:35 ', 'flight')
solve('ahah Second-Testov )*))&&ba SOF/VAR ela** FB973 - Bulgaria*Air -opFB900 pa-SOF/VAr//_- T12G12 STD08:45  STA09:35 ', 'all')
solve('ahah Tad-T.-Testov )*))&&ba SOF/VAR ela** FB973 - Bulgaria*Air -opFB900 pa-SOF/VAr//_- T12G12 STD08:45  STA09:35 ', 'all')
solve('ahah Second-Testov )*))&&ba SOF/VAR ela** FB973 - Bulgaria*Air -opFB900 pa-SOF/VAr//_- T12G12 STD08:45  STA09:35 ', 'company')