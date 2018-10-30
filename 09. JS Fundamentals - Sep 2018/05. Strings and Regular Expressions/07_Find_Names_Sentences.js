function findSentences (input) {
  let pattern = /(?<!_)(?:_)([a-zA-Z0-9]+)(?:\s)(?![_])/gm;
  let str = input + ' ';

  let matches = [];
  let match;
  while (match = pattern.exec(str)) {
      matches.push(match[1]);
  }

  console.log(matches.join(','));
}