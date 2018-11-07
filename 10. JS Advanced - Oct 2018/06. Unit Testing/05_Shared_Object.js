let assert = require('chai').assert;
let jsdom = require('jsdom-global')();
let $ = require('jquery');

let sharedObject = {
  name: null,
  income: null,
  changeName: function (name) {
    if (name.length === 0) {
      return;
    }
    this.name = name;
    let newName = $('#name');
    newName.val(this.name);
    console.log(this.name);
  },
  changeIncome: function (income) {
    if (!Number.isInteger(income) || income <= 0) {
      return;
    }
    this.income = income;
    let newIncome = $('#income');
    newIncome.val(this.income);
    console.log(this.income);
  },
  updateName: function () {
    let newName = $('#name').val();
    if (newName.length === 0) {
      return;
    }
    this.name = newName;
    console.log(this.name);
  },
  updateIncome: function () {
    let newIncome = $('#income').val();
    if (isNaN(newIncome) || !Number.isInteger(Number(newIncome)) || Number(newIncome) <= 0) {
      return;
    }
    this.income = Number(newIncome);
    console.log(this.income);
  }
}

describe('sharedObject', function () {
  let nameField;
  let incomeField;

  beforeEach('Init HTML', function () {
    document.body.innerHTML =
      `<div id="wrapper">
      <table class="table">
        <thead>
          <tr>
            <td><input type="text" id="name"></td>
            <td><input type="text" id="income"></td>
          </tr>
        </thead>
        <tbody>
          <tr>
            <td><button type='submit' id='changeName'>Change Name</button></td>
            <td><button type='submit' id='changeIncome'>Change Income</button></td>
          </tr>
          <tr>
            <td><button type='submit' id='updateName'>Update Name</button></td>
            <td><button type='submit' id='updateIncome'>Update Income</button></td>
          </tr>
        </tbody>
      </table>
    </div>`

    nameField = document.getElementById('name');
    incomeField = document.getElementById('income');
  });

  it('name field initial state should return string empty', function () {
    assert.equal(nameField.value, '', "Function did not return the correct result!");
  });

  it('name field initial state of the object should return null', function () {
    assert.equal(sharedObject.name, null, "Function did not return the correct result!");
  });

  it('income field initial state should return string empty', function () {
    assert.equal(incomeField.value, '', "Function did not return the correct result!");
  });

  it('income field initial state of the object should return null', function () {
    assert.equal(sharedObject.income, null, "Function did not return the correct result!");
  });

  it('with empty name string should return empty name field', function () {
    let oldVal = $('#name').val();
    sharedObject.changeName('');
    assert.equal($('#name').val(), oldVal, "Function did not return the correct result!");
  });

  it('with empty income string should return empty income field', function () {
    let oldVal = $('#income').val();
    sharedObject.changeIncome('');
    assert.equal($('#income').val(), oldVal, "Function did not return the correct result!");
  });

  it('with new value name string should return new name string field', function () {
    sharedObject.changeName('pesho');
    let newVal = 'gosho';
    $('#name').val(newVal);
    sharedObject.updateName();
    assert.equal($('#name').val(), newVal, "Function did not return the correct result!");
  });

  it('with new value name string should return new name string field', function () {
    sharedObject.changeIncome(123);
    let newVal = 111;
    $('#income').val(newVal);
    sharedObject.updateIncome();
    assert.equal($('#income').val(), newVal, "Function did not return the correct result!");
  });

  it('with string value should return parsed to number', function () {
    $('#income').val('123');
    sharedObject.updateIncome();
    assert.equal(sharedObject.income, 123, "Function did not return the correct result!");
  });

  it('with string value should return parsed to number', function () {
    sharedObject.changeIncome(1);
    assert.equal(sharedObject.income, 1, "Function did not return the correct result!");
  });

  it("should keep the old value when function called with non-number income", function () {
    sharedObject.changeIncome(15);
    sharedObject.changeIncome("20");

    let objectIncome = sharedObject.income;
    let documentIncome = $("#income").val();
    let expected = 15;

    assert.equal(objectIncome, expected);
    assert.equal(documentIncome, expected.toString());
  });

  it('with negative value should preserve last entered value', function() {
    sharedObject.changeIncome(10);
    sharedObject.changeIncome(-1);

    assert.equal(sharedObject.income, 10, "Function did not return the correct result!");
  });
})