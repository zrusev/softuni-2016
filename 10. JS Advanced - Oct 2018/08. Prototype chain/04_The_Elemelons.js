function solve() {
  class Melon {
    constructor(weight, melonSort) {
      if (new.target === Melon) {
        throw new TypeError("Abstract class cannot be instantiated directly");
      }

      this.weight = weight;
      this.melonSort = melonSort;
    }

    get elementIndex() {
      return this.weight * this.melonSort.length;
    }

    toString() {
      return `Element: ${this.element}\n` +
        `Sort: ${this.melonSort}\n` +
        `Element Index: ${this.elementIndex}`;
    }
  }

  class Watermelon extends Melon {
    constructor(weight, melonSort) {
      super(weight, melonSort);
     
      this.elementIndex;
      this.element = 'Water';
    }
  }

  class Firemelon extends Melon {
    constructor(weight, melonSort) {
      super(weight, melonSort);
     
      this.elementIndex;
      this.element = 'Fire';
    }
  }

  class Earthmelon extends Melon {
    constructor(weight, melonSort) {
      super(weight, melonSort);

      this.elementIndex;
      this.element = 'Earth';
    }
  }

  class Airmelon extends Melon {
    constructor(weight, melonSort) {
      super(weight, melonSort);

      this.elementIndex;
      this.element = 'Air';
    }
  }

  class Melolemonmelon extends Watermelon {
    constructor(weight, melonSort) {
      super(weight, melonSort);

      this.elements = ['Fire', 'Earth', 'Air', 'Water'];
      this.morphs = 3;
    }

    morph() {
      this.morphs++;
      return this;
    }

    toString() {
      return `Element: ${this.elements[this.morphs % 4]}\n` +
        `Sort: ${this.melonSort}\n` +
        `Element Index: ${this.elementIndex}`;
    }
  }

  return {
    Melon,
    Watermelon, 
    Firemelon, 
    Earthmelon, 
    Airmelon,
    Melolemonmelon
  }
}

let wm = solve();
let watermelon = new wm.Watermelon(5, 'Rotten');
console.log(watermelon.toString());
