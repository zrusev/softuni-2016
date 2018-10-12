function uniqueSequences(input) {
 
  let arrays = new Map;
  for (let line of input) {
      let array = JSON.parse(line).map(Number).sort((a, b) => b - a);
      let toStore = `[${array.join(', ')}]`;
      if (!arrays.has(toStore)){
          arrays.set(toStore, array.length);
      }

  }
  let customSort = (arrA, arrB, map) => map.get(arrA) - map.get(arrB);
  console.log([...arrays.keys()].sort((a, b) => customSort(a, b, arrays)).join('\n'));
}