let expect = require('chai').expect;

function lookupChar(string, index) {
  if (typeof(string) !== 'string' || !Number.isInteger(index)) {
      return undefined;
  }
  if (string.length <= index || index < 0) {
      return "Incorrect index";
  }

  return string.charAt(index);
}


describe('lookupChar', function() {
  it('with a non-string first parameter should return undefined', function() {
    expect(lookupChar(12, 1)).to.equal(undefined, "Function did not return the correct result!");
  });

  it('with a non-numeric second parameter should return undefined', function() {
    expect(lookupChar('string', 's')).to.equal(undefined, "Function did not return the correct result!");
  });

  it('with a floating point second parameter should return undefined', function() {
    expect(lookupChar('string', 1.3)).to.equal(undefined, "Function did not return the correct result!");
  });

  it('with an incorrect index value should return incorrect index', function() {
    expect(lookupChar('string', 100)).to.equal('Incorrect index', "Function did not return the correct result!");
  });

  it('with a negative index value should return incorrect index', function() {
    expect(lookupChar('string', -1)).to.equal('Incorrect index', "Function did not return the correct result!");
  });

  it('with an index equal to string length should return incorrect index', function() {
    expect(lookupChar('string', 6)).to.equal('Incorrect index', "Function did not return the correct result!");
  });

  it('with correct parameters should return correct value', function() {
    expect(lookupChar('string', 5)).to.equal('g', "Function did not return the correct result!");
  });
});