const system = (() => {
  let arr = [];

  let obj = {
    order: '',
    read: function (input, order) {
      input.forEach(element => {
        let vals = element.split('|');
        let t = new Ticket(vals[0], vals[1], vals[2]);
        arr.push(t);
      });

      this.order = order;

      return this;
    },
    sort: function () {
      let sorted = arr.sort((a, b) => {
        return a[this.order] > b[this.order];
      });

      return sorted;
    }
  }

  class Ticket {
    constructor(destination, price, status) {
      this.destination = destination;
      this.price = +price;
      this.status = status;
    }
  }

  return obj;
})()


console.log(system
  .read(
    ['Philadelphia|94.20|available',
      'New York City|95.99|available',
      'New York City|95.99|sold',
      'Boston|126.20|departed'
    ],
    'status')
  .sort());