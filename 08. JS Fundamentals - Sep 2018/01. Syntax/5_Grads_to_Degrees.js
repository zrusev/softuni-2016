function gradsToDegrees(input) {
  let grads = Number(input);

  grads = grads % 400;
  if (grads < 0) {
      grads += 400;
  }
  //or grads = grads < 0 ? 400 + grads : grads;
  let degrees = grads / 400 * 360;//or let degrees = grads*0.9
  console.log(degrees);
}

gradsToDegrees(100);