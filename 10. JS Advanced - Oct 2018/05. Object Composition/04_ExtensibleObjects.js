function extendObject() {
  let obj = {
    extend
  };

  return obj;

  function extend(template) {
    let keys = Object.keys(template);

    for (let key of keys) {
      let value = template[key];

      if (typeof value === "function") {
        Object.getPrototypeOf(this)[key] = value;
      } else {
        this[key] = value;
      }
    }
  }
}

let object = extendObject();
object.extend({
  walk: function () {},
  distance: 20
});
console.log(object);