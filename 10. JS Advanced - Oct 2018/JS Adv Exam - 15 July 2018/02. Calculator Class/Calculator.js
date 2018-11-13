let assert = require('chai').assert;

class Calculator {
    constructor() {
        this.expenses = [];
    }

    add(data) {
        this.expenses.push(data);
    }

    divideNums() {
        let divide;
        for (let i = 0; i < this.expenses.length; i++) {
            if (typeof (this.expenses[i]) === 'number') {
                if (i === 0 || divide === undefined) {
                    divide = this.expenses[i];
                } else {
                    if (this.expenses[i] === 0) {
                        return 'Cannot divide by zero';
                    }
                    divide /= this.expenses[i];
                }
            }
        }
        if (divide !== undefined) {
            this.expenses = [divide];
            return divide;
        } else {
            throw new Error('There are no numbers in the array!')
        }
    }

    toString() {
        if (this.expenses.length > 0)
            return this.expenses.join(" -> ");
        else return 'empty array';
    }

    orderBy() {
        if (this.expenses.length > 0) {
            let isNumber = true;
            for (let data of this.expenses) {
                if (typeof data !== 'number')
                    isNumber = false;
            }
            if (isNumber) {
                return this.expenses.sort((a, b) => a - b).join(', ');
            } else {
                return this.expenses.sort().join(', ');
            }
        } else return 'empty';
    }
}

describe('Calculator', function () {
    let instance;

    beforeEach('Initiate', () => {
        instance = new Calculator();
    })

    it('empty arrays are arrays', function () {
        assert.isArray(instance.expenses, "Function did not return the correct result!");
    });

    it('empty arrays are arrays', function () {
        assert.typeOf(instance.expenses, 'array', "Function did not return the correct result!");
    });

    it('contains a property expenses that is initialized to an empty array', function () {
        assert.equal(instance.expenses.length, 0, "Function did not return the correct result!");
    });

    it('with data should return correct result', function () {
        instance.add(10);
        assert.equal(instance.toString(), '10', "Function did not return the correct result!");
    });

    it('adds the passed in item to the expenses', function () {
        instance.add(10);
        assert.equal(instance.expenses.length, 1, "Function did not return the correct result!");
    });

    it('adds the passed in item to the expenses', function () {
        instance.add(10);
        instance.add('test');
        assert.include(instance.expenses, 10, "Function did not return the correct result!");
        assert.include(instance.expenses, 'test', "Function did not return the correct result!");
    });

    it('should throw error if no numbers are pushed', function () {
        instance.add('test');
        assert.throws(() => instance.divideNums(), Error, 'There are no numbers in the array!', "Function did not return the correct result!");
    });

    it('divides only the numbers from the expenses  and returns the result', function () {
        instance.add('test');
        instance.add(10);
        assert.equal(instance.divideNums(), 10, "Function did not return the correct result!");
    });

    it('should return the string empty array', function () {
        assert.equal(instance.toString(), "empty array", "Function did not return the correct result!");
    });

    it('should return a string, containing a list of all items from the expenses, joined with an arrow', function () {
        instance.add(10);
        instance.add('Test');
        assert.equal(instance.toString(), "10 -> Test", "Function did not return the correct result!");
    });

    it('should return a string, containing a list of all sorted items from the expenses when numbers, joined with an arrow', function () {
        instance.add(10);
        instance.add(1);
        instance.add(100);
        assert.equal(instance.orderBy(), "1, 10, 100", "Function did not return the correct result!");
    });

    it('should return a string, containing a list of all sorted items from the expenses when not numbers, joined with an arrow', function () {
        instance.add('abc');
        instance.add('aab');
        instance.add('aaa');
        assert.equal(instance.orderBy(), "aaa, aab, abc", "Function did not return the correct result!");
    });
});