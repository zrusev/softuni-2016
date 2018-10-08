function capitalizeWords (input) {
  console.log(input.toLowerCase().replace(/\b\w/g, function(l){ return l.toUpperCase() }))
}