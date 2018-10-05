function lastDay ([day, month, year]) {
  console.log(new Date(year, month - 1, 0).getDate());
}

lastDay([13, 12, 2004]);