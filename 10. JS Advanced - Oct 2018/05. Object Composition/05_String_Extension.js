(function () {
  String.prototype.ensureStart = function (str) {
    const currentStr = this.valueOf();

    if (currentStr.indexOf(str) === 0) {
      return currentStr;
    }

    return str + currentStr;
  }

  String.prototype.isEmpty = function () {
    return str.valueOf() !== "";
  }

  String.prototype.ensureEnd = function (strEnd) {
    if (str.valueOf() !== "") {
      return str + strEnd;
    }
  }

  String.prototype.truncate = function (n) {
    if (str.length < n) {
      return str;
    } else {
      let arr = str.split(' ');
      arr.pop();
      arr.push("...");
    }

    return arr.join(' ');
  }
})();


let str = 'my string'
str = str.ensureStart('my')
str = str.ensureEnd(' hello')
str = str.truncate(3)
console.log(str);
str = str.truncate(14)
str = str.truncate(8)
str = str.truncate(4)
str = str.truncate(2)
str = String.format('The {0} {1} fox',
  'quick', 'brown');
str = String.format('jumps {0} {1}',
  'dog');