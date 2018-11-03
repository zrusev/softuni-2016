let solve = (function () {
  let sum = 0;

  return function add(input) {
    sum += input;

    add.toString = function() {
      return sum;
    }

    return add;
  }
})();

console.log(solve(8)(1).toString());