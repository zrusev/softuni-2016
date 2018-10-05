function solve(input) {
  let v1 = +input[0];
  let v2 = +input[1];
  let timeInHours = +input[2] / 3600;

  console.log(Math.abs((v1 * timeInHours) - (v2 * timeInHours)) * 1000);
}

solve([11, 10, 120]);