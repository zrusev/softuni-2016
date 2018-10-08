function findNumbers (input) {
  let pattern = /\d+/gm;
  let result = [];

  input.forEach((el, ind) => {
    if (pattern.test(el)) {
      let found = el.match(pattern);
      found.forEach(el => result.push(el));
    }
  })

  console.log(result.join(' '));
}