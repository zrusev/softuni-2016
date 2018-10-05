function figureOf4Squares (n) {
  let container = [];
  let rows = 0;

  if(+n %2 === 0) {
    rows = n - 1;
  } else {
    rows = n;
  }

  for(let row = 1; row <= rows; row++) {
    let middleRow = Math.floor(rows / 2) + 1;

    if(row === 1 || row === middleRow || row === rows) {
      container.push(`+`);

      for(let col = 1; col < 2 * +n - 2; col++) {
        let middleCol = Math.floor((2 * +n - 1) / 2);
  
        if(col === middleCol) {
          container.push(`+`);        
        } else {
          container.push(`-`);
        }
      }

      container.push(`+\n`);
    } else {
      container.push(`|`);

      for(let col = 1; col < 2 * +n - 2; col++) {
        let middleCol = Math.floor((2 * +n - 1) / 2);
  
        if(col === middleCol) {
          container.push(`|`);        
        } else {
          container.push(` `);
        }
      }

      container.push(`|\n`);
    }

  }

  console.log(container.join(''));
}

figureOf4Squares(5);