class Vacationer {
  constructor(fullName, creditCard) {
    this.fullName = fullName;
    this.idNumber = this.generateIDNumber();
    this.creditCard = creditCard;
    this.wishList = [];
  }

  get creditCard() {
    return this._creditCard;
  }

  set creditCard(val) {
    if (val === undefined) {
      this._creditCard = {
        cardNumber: 1111,
        expirationDate: "",
        securityNumber: 111
      }
    } else {
      this.addCreditCardInfo(val);    
    }
  }

  set fullName(val) {
    if (val.length !== 3) {
      throw new Error('Name must include first name, middle name and last name');
    }

    val.forEach((el) => {
      let pattern = /^[A-Z][a-z]+$/g;
      if (!pattern.test(el)) {
        throw new Error('Invalid full name');
      }
    });

    this._fullName = {
      firstName: val[0],
      middleName: val[1],
      lastName: val[2]
    };
  }

  get fullName() {
    return this._fullName;
  }

  generateIDNumber() {
    let charCode = this.fullName.firstName.charCodeAt(0);
    let middleLength = this.fullName.middleName.length;
    let vowel = isVowel(this.fullName.lastName[this.fullName.lastName.length - 1]) ? 8 : 7;

    return 231 * charCode + 139 * middleLength + vowel.toString();

    function isVowel(c) {
      return ['a', 'e', 'i', 'o', 'u'].indexOf(c.toLowerCase()) !== -1
    }
  }

  addCreditCardInfo(input) {
    if (input.length !== 3) {
      throw new Error('Missing credit card information');
    }

    if (!Number.isInteger(input[0]) || typeof input[1] !== 'string' ||  !Number.isInteger(input[2])) {
      throw new Error('Invalid credit card details');
    }

    this._creditCard = {
      cardNumber: +input[0],
      expirationDate: input[1],
      securityNumber: +input[2]
    }
  }

  addDestinationToWishList(destination) {
    if (this.wishList[destination]) {
      throw new Error('Destination already exists in wishlist');
    }

    this.wishList.push(destination);

    this.wishList = this.wishList.sort((a, b) => a.length - b.length);
  }

  getVacationerInfo() {
    let destinations = this.wishList.length === 0 ? "empty" : this.wishList.join(', ');

    return `Name: ${this.fullName.firstName} ${this.fullName.middleName} ${this.fullName.lastName}\nID Number: ${this.idNumber}\nWishlist:\n${destinations}\nCredit Card:\nCard Number: ${this.creditCard.cardNumber}\nExpiration Date: ${this.creditCard.expirationDate}\nSecurity Number: ${this.creditCard.securityNumber}`;
  }
}

