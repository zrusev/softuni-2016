function convertInches(inches) {
  let feetFromInches = Math.floor(inches / 12);//There are 12 inches in a foot
  let inchesRemainder = inches % 12;

  let result = feetFromInches + "'-" + inchesRemainder + "\"";
  console.log(result);
}

convertInches(55);