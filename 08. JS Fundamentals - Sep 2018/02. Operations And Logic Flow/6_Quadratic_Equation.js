function solve(a, b, c) {
  var result = (-1 * b + Math.sqrt(Math.pow(b, 2) - (4 * a * c))) / (2 * a);
  var result2 = (-1 * b - Math.sqrt(Math.pow(b, 2) - (4 * a * c))) / (2 * a);

  if (result === result2) {
    console.log (result);
  } else if (result !== result2 && isNaN(result) === false && isNaN(result2) === false) {
    console.log (result2);
    console.log (result);
  } else {
    console.log('No');
  }
}

solve(5, 2, 1);