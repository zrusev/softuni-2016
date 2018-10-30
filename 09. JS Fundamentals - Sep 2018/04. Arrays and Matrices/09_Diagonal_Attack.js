function reDrawMatrix (input) {
  let matrix = [];
  input.forEach((el, ind) => matrix[ind] = el.split(' '));

  let temp = 0;
  let temp2 = 0;
  let equal = 
  matrix.forEach((el, ind) => temp += +matrix[ind][ind])
  ===
  matrix.forEach((el, ind) => temp2 += +matrix[el.length - ind - 1][el.length - ind - 1]);

  if (!equal) {
    printMatrix(matrix);
  }

  matrix.forEach((el, ind) => {
    el.forEach((e, i) => {
      if (ind !== i && el.length - ind - 1 !== i) {
        matrix[ind][i] = temp
      }
    })
  })

  printMatrix(matrix);

  function printMatrix (matrix) {
    matrix.forEach(el => console.log(el.join(' ')));
  }
}