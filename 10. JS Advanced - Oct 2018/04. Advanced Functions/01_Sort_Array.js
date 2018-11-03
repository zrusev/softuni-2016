const sorter = (() => {
  const s = {
    "asc": function (input) {
      console.log(input.sort((a, b) => a - b));
    },
    "desc": function (input) {
      console.log(input.sort((a, b) => b - a));
    },
    "read" : function (input, action) {
      s[action](input);
    }
  }

  let arr = [];
  
  const result = {};

  Object.keys(s).forEach((key) => {
    result[key] = function () {

      for (let i = 0; i < arguments.length; i++) {
        arr.push(arguments[i]);        
      }

      const action = s[key];

      action.apply(null, arr);
    }
  })

  return result;
})();

sorter.read([14, 7, 17, 6, 8], 'asc');