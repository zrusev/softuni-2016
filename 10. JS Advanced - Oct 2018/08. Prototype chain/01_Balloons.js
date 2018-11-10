function solve() {
  class Balloon {
    constructor(color, gasWeight) {
      this.color = color;
      this.gasWeight = gasWeight;
    }
  }

  class PartyBalloon extends Balloon {
    constructor(color, gasWeight, ribbonColor, ribbonLength) {
      super(color, gasWeight);

      this.ribbon = {
        color: ribbonColor,
        length: ribbonLength
      }
    }

    get ribbon() {
      return this._ribbon;
    }

    set ribbon(val) {
      this._ribbon = val;
    }
  }

  class BirthdayBalloon extends PartyBalloon {
    constructor(color, gasWeight, ribbonColor, ribbonLength, text) {
      super(color, gasWeight, ribbonColor, ribbonLength);

      this.text = text;
    }

    get text() {
      return this._text;
    }

    set text(val) {
      this._text = val;
    }
  }

  return {
    Balloon,
    PartyBalloon,
    BirthdayBalloon
  }
}