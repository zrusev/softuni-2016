function uSequences (input) {
  let fullInput = [];
  
  input.forEach((l) => {
    let data = JSON.parse(l);
    fullInput.push(data);
  })

  let last = [];
  let u = [];
  fullInput
  .forEach((a, ind) => {
    let r = a.reduce((acc, cur) => {
      return acc + +cur;
    }, 0)
    
    if(u.indexOf(r) > -1) {
      fullInput.splice(ind, 1);
    } else {
      u.push(r);
      last.push(a);
    }
  });

  let sorted = last.sort((a, b) => a.length - b.length);

  sorted.forEach((a) => {
    console.log("[" + a.sort((a, b) => b - a).join(', ') + "]"); 
  })
}

uSequences(["[-3, -2, -1, 0, 1, 2, 3, 4]",
"[10, 1, -17, 0, 2, 13]",
"[4, -3, 3, -2, 2, -1, 1, 0]"]


)