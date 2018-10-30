function drawTrianlesOfDollars(n) {
  let line = '';
  let row = +n;

  for(let col = 1; col <= row; col++) {
    line += '$';
    console.log(line);
  }
}

drawTrianlesOfDollars(5);