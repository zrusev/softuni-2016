function distanceVector([x0,y0,z0,x1,y1,z1]){
  let dx = x0 - x1;
  let dy = y0 - y1;
  let dz = z0 - z1;

  console.log(Math.sqrt( dx * dx + dy * dy + dz * dz ));
}

distanceVector([1, 1, 0, 5, 4, 0]);