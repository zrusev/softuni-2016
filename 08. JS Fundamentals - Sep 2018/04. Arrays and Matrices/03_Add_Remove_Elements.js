function AddRemoveElemnets (input) {
  let initialValue = 0;
  let copy = [];

  input.forEach((el) => {
      ++initialValue;

      if(el === 'add') {
        copy.push(initialValue);
      } else {
        copy.pop();
      }
  })

  if(copy.length === 0) {
    console.log("Empty");
  } else {
    console.log(copy.join('\n'));
  }
}