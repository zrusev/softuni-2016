function Extract (input) {
  let highestNumber = 0;
  

  let copy =  input.filter(el => {
    if (el >= highestNumber) {
      highestNumber = el;
      return el;
    }
  })

  console.log(copy.join('\n'));
}
