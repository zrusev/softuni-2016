class Stringer {
  constructor(innerString, innerLength) {
    this._innerLength;
    this.innerString = innerString;
    this.innerLength = innerLength;
  }

  get innerLength() {
    return this._innerLength;
  }

  set innerLength(val) {
    if (val <= 0) {
      this._innerLength = 0;

    } else {
      this._innerLength = val
    }
  }

  increase(length) {
    this.innerLength += length;
  };

  decrease(length) {
    this.innerLength -= length;
  };

  toString() {
    if (this.innerString.length > this.innerLength) {
      return this.innerString.slice(0, this.innerLength) + '...';
    } else if (this.innerString.length === 0) {
      return '...';
    }

    return this.innerString;
  }
}

let test = new Stringer("Test", 5);
console.log(test.toString()); //Test

test.decrease(3);
console.log(test.toString()); //Te...

test.decrease(5);
console.log(test.toString()); //...

test.increase(4);
console.log(test.toString()); //Test