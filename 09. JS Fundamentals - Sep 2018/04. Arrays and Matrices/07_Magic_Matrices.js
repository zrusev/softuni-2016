function Magic (input) {
  let total = input[0].reduce((a, b) => a + b, 0);

  let result = 
  input
    .every(el => el
      .reduce((a, b) => a + b, 0) === total) 
    ||
  input
    .reduce((a, b) => a
      .map((x, i) => x + (b[i] || 0))) === total;
  
  console.log(result);

  function check (line) {
    return line.reduce((a, b) => a + b, 0) === total;
  }
}

Magic(
  [[1, 0, 0],
  [0, 0, 1],
  [0, 1, 0]]
 )