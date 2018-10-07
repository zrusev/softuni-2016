function PrintN (input) {
  let copy = input.splice(0);
  
  let n = copy.pop();
  console.log(copy
    .filter ((el, ind) => {
      return ind % n === 0;
    })
    .join('\n'))
}

PrintN(['5', 
'20', 
'31', 
'4', 
'20', 
'2']
);