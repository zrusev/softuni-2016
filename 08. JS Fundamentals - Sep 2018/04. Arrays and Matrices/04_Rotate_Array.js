function RotateElements (input) {
  let n = +input.pop();
  let copy = input.slice(0);

  let rotations = n % copy.length;
  for (let i = 0; i < rotations; i++) {
    copy.unshift(copy.pop());
  }

  console.log(copy.join(' '));
}

RotateElements(
['Banana', 
'Orange', 
'Coconut', 
'Apple', 
'15']
)

// RotateElements(['1', 
// '2', 
// '3', 
// '4', 
// '2']
// );