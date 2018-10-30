function Sorting (input) {
  function compare (a, b) {
    if (a.length > b.length) {
      return 1;
    } else if (a.length < b.length) {
      return -1;
    } else {
      if (a < b) {
        return -1;
      } else if (a > b) {
        return 1;
      } else {
        return 0;
      }
    }
  }
  
  console.log(input.sort(compare).join('\n'));
}

Sorting(['test', 
'Deny', 
'omen', 
'Default']
)