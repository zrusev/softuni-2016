let assert = require('chai').assert;

let mathEnforcer = {
  addFive: function (num) {
      if (typeof(num) !== 'number') {
          return undefined;
      }
      return num + 5;
  },
  subtractTen: function (num) {
      if (typeof(num) !== 'number') {
          return undefined;
      }
      return num - 10;
  },
  sum: function (num1, num2) {
      if (typeof(num1) !== 'number' || typeof(num2) !== 'number') {
          return undefined;
      }
      return num1 + num2;
  }
};

describe('mathEnforcer', function() {
  describe('addFive', function() {
    it('with a number parameter should return correct result', function() {
      assert.equal(mathEnforcer.addFive(5), 10, "Function did not return the correct result!");
    });

    it('with a non-number parameter should return undefined', function() {
      assert.equal(mathEnforcer.addFive('5'), undefined, "Function did not return the correct result!");
    });

    it('with a floating point parameter should return a floating point result', function() {
      assert.equal(mathEnforcer.addFive(5.1), 10.1, "Function did not return the correct result!");
    });

    it('with a negative number should return correct result', function() {
      assert.equal(mathEnforcer.addFive(-10), -5, "Function did not return the correct result!");
    });

    it('with a floating point parameter should return correct result within 0.01', function() {
      assert.closeTo(mathEnforcer.addFive(5.1), 10.2, 0.1, "Function did not return the correct result!");
    });
  });

  describe('subtractTen', function() {
    it('with a number parameter should return correct result', function() {
      assert.equal(mathEnforcer.subtractTen(10), 0, "Function did not return the correct result!");
    });

    it('with a non-number parameter should return undefined', function() {
      assert.equal(mathEnforcer.subtractTen('10'), undefined, "Function did not return the correct result!");
    });

    it('with a floating point parameter should return a floating point result', function() {
      assert.equal(mathEnforcer.subtractTen(20.5), 10.5, "Function did not return the correct result!");
    });

    it('with a negative number should return correct result', function() {
      assert.equal(mathEnforcer.subtractTen(-10), -20, "Function did not return the correct result!");
    });

    it('with a floating point parameter should return correct result within 0.01', function() {
      assert.closeTo(mathEnforcer.subtractTen(10.5), 0.4, 0.1, "Function did not return the correct result!");
    });
  });

  describe('sum', function(){
    it('with a number parameter should return correct result', function() {
      assert.equal(mathEnforcer.sum(5, 5), 10, "Function did not return the correct result!");
    });

    it('with a non-number parameter should return undefined', function() {
      assert.equal(mathEnforcer.sum('5', 5), undefined, "Function did not return the correct result!");
    });

    it('with a floating point parameter should return a floating point result', function() {
      assert.equal(mathEnforcer.sum(5.1, 5.1), 10.2, "Function did not return the correct result!");
    });

    it('with a floating point parameter should return correct result within 0.01', function() {
      assert.closeTo(mathEnforcer.sum(10.5, 1), 11.5, 0.1, "Function did not return the correct result!");
    });
  });
});