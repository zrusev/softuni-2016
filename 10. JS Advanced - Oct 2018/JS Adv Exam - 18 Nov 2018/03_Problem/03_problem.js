class Vacation {
  constructor(organizer, destination, budget) {
    this.organizer = organizer;
    this.destination = destination;
    this.budget = budget;
    this.kids = {};
  };

  get numberOfChildren() {
    let allKids = 0;
    Object.values(this.kids).reduce((ind, el) => {
      allKids += el.length;
    }, allKids);

    return allKids;
  }

  registerChild(name, grade, budget) {
    let currentKid = `${name}-${budget}`;

    if (+budget < this.budget) {
      return `${name}'s money is not enough to go on vacation to ${this.destination}.`;
    }

    if (!this.kids[+grade]) {
      this.kids[+grade] = [];
    }

    if (!this.kids[+grade].includes(currentKid)) {
      this.kids[+grade].push(currentKid);
    } else {
      return `${name} is already in the list for this ${this.destination} vacation.`;
    }

    return this.kids[+grade];
  }

  removeChild(name, grade) {
    let kidIndex = -1;

    if (this.kids[+grade] === undefined) {
      return `We couldn't find ${name} in ${grade} grade.`
    }

    this.kids[+grade].map((el, index) => {
      if (el.includes(name)) {
        return kidIndex = index;
      }
    });

    if (kidIndex > -1) {
      this.kids[+grade].splice(kidIndex, 1);
      return this.kids[+grade];
    } else {
      return `We couldn't find ${name} in ${grade} grade.`
    }
  }

  toString() {

    let allKids = 0;
    Object.values(this.kids).reduce((ind, el) => {
      allKids += el.length;
    }, allKids);

    if (allKids === 0) {
      return `No children are enrolled for the trip and the organization of ${this.organizer} falls out...`;
    }

    let result = `${this.organizer} will take ${allKids} children on trip to ${this.destination}\n`;

    Object.keys(this.kids).map((gr) => {
      result += `Grade: ${gr}\n`;

      this.kids[gr].forEach((el, ind) => {
        result += `${ind + 1}. ${el}\n`
      })

    })

    return result;
  }
}


let vacation = new Vacation('Miss. Elizabeth', 'The bahamas', 400);

vacation.registerChild('Gosho', 12, 3400);
vacation.registerChild('Pesho', 12, 400);
vacation.registerChild('Pesho', 12, 400);
vacation.registerChild('Skaro', 11, 400);
vacation.registerChild('Gosho', 11, 3444);

console.log(vacation.numberOfChildren);