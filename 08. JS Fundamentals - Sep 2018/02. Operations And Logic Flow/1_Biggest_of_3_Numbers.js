function biggestNumber (input) {
  let num1 = +input[0];
  let num2 = +input[1];
  let num3 = +input[2];

  return Math.max(num1, num2, num3);
}

console.log(biggestNumber([-10, -20, -30]));