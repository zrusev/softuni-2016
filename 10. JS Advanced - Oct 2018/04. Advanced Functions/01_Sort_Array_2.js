function sortArray(input, sortMethod) {
  let ascComparator = function (a, b) {
    return a - b
  };
  let descComparator = function (a, b) {
    return b - a
  };

  let sortingStrategies = {
    "asc": ascComparator,
    "desc": descComparator
  }

  return input.sort(sortingStrategies[sortMethod]);
}