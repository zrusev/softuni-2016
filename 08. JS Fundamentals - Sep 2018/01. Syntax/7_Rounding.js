function rounding(input) {
  let num = +input[0].toFixed(input[1]);
  console.log(num.toString());
}

rounding([10.5, 3]);
