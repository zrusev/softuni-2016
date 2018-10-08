function extractLinks (arr) {
  let inputAsString = arr.join(' ');
  let regex = /www\.[a-zA-Z0-9-]+(\.[a-z]+)+/gm;
  let arrOfMatches = inputAsString.match(regex);

  if(arrOfMatches === null) {
    console.log();
  } else {
    console.log(arrOfMatches.join('\n'));
  }

}