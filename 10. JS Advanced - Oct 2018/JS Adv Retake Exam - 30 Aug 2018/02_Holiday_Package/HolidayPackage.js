let assert = require('chai').assert;
let expect = require('chai').expect;

class HolidayPackage {
  constructor(destination, season) {
    this.vacationers = [];
    this.destination = destination;
    this.season = season;
    this.insuranceIncluded = false; // Default value
  }

  showVacationers() {
    if (this.vacationers.length > 0)
      return "Vacationers:\n" + this.vacationers.join("\n");
    else
      return "No vacationers are added yet";
  }

  addVacationer(vacationerName) {
    if (typeof vacationerName !== "string" || vacationerName === ' ') {
      throw new Error("Vacationer name must be a non-empty string");
    }
    if (vacationerName.split(" ").length !== 2) {
      throw new Error("Name must consist of first name and last name");
    }
    this.vacationers.push(vacationerName);
  }

  get insuranceIncluded() {
    return this._insuranceIncluded;
  }

  set insuranceIncluded(insurance) {
    if (typeof insurance !== 'boolean') {
      throw new Error("Insurance status must be a boolean");
    }
    this._insuranceIncluded = insurance;
  }

  generateHolidayPackage() {
    if (this.vacationers.length < 1) {
      throw new Error("There must be at least 1 vacationer added");
    }
    let totalPrice = this.vacationers.length * 400;

    if (this.season === "Summer" || this.season === "Winter") {
      totalPrice += 200;
    }

    totalPrice += this.insuranceIncluded === true ? 100 : 0;

    return "Holiday Package Generated\n" +
      "Destination: " + this.destination + "\n" +
      this.showVacationers() + "\n" +
      "Price: " + totalPrice;
  }
}

describe('HolidayPackage', () => {
  let instance;
  beforeEach('initialize class', () => {
    instance = new HolidayPackage('Italy', 'Summer');
  })

  it("should be initiate with two string arguments", () => {
    assert.instanceOf(instance, HolidayPackage, "Function did not return the correct result.");
  });

  it("should be initiate with two string arguments", () => {
    assert.equal(typeof instance.destination, 'string', "Function did not return the correct result.");
    assert.equal(typeof instance.season, 'string', "Function did not return the correct result.");
    assert.notEqual(typeof instance.destination, '', "Function did not return the correct result.");
    assert.notEqual(typeof instance.season, '', "Function did not return the correct result.");
  });
});

describe('HolidayPackage', function () {
  let holidayPackage;
  beforeEach(function () {
    holidayPackage = new HolidayPackage('Italy', 'Summer');
  });

  it('insuranceIncluded must have defalut value - false', function () {
    expect(holidayPackage.insuranceIncluded).to.equal(false);
  });
  it('Show message if no vacationers added', function () {
    expect(holidayPackage.showVacationers()).to.equal('No vacationers are added yet');
  });
  it('generateHolidayPackage must throw an error', function () {
    expect(() => holidayPackage.generateHolidayPackage()).to.throw();
  });
  it('addVacationer must throw an error for adding non-string', function () {
    expect(() => holidayPackage.addVacationer(1)).to.throw();
  });
  it('addVacationer must throw an error for adding empty string', function () {
    expect(() => holidayPackage.addVacationer(" ")).to.throw();
  });
  it('addVacationer must throw an error for adding only one name', function () {
    expect(() => holidayPackage.addVacationer('Pesho')).to.throw();
  });
  it('showVacationers must show correct message', function () {
    holidayPackage.addVacationer('Ivan Ivanov');
    holidayPackage.addVacationer('Pesho Peshov');
    expect(holidayPackage.showVacationers()).to.equal('Vacationers:\nIvan Ivanov\nPesho Peshov')
  });
  it('generateHolidatPackage must show a correct sum for Summer season', function () {
    holidayPackage.addVacationer('Ivan Ivanov');
    holidayPackage.addVacationer('Pesho Peshov');
    holidayPackage.insuranceIncluded = true;
    expect(holidayPackage.generateHolidayPackage())
      .to
      .equal('Holiday Package Generated\nDestination: Italy\nVacationers:\nIvan Ivanov\nPesho Peshov\nPrice: 1100');
  })
});