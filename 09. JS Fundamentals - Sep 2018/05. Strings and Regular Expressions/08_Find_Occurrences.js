function countOccurences (input, key) {
  let pattern = new RegExp("(?:[^\w])?(" + key + ")(?:[^\\w])", "gmi");
  let temp = 0;
  let m;

  do {
    m = pattern.exec(input);
    if (m) {
        temp++;
    }
  } while (m);
  
  console.log(temp);
}

countOccurences('There was one. Therefore I bought it. I wouldn’t buy it otherwise.', 
'there')