function dNAex(input) {
  let pattern = /([a-z\!\@\#\$\?]+)=([\d]+)--([\d]+)<<([a-z]+)/;
  let summary = [];

  for (let line of input) {
    if (line === "Stop!") {
      break;
    }

    let found = pattern.exec(line);
    if (found != null) {
      let genomeName = found[1].replace(/[\!\@\#\$\?]+/gi, '');
      let genomeNameLength = +found[2];
      let organismCount = +found[3];
      let organismName = found[4];

      if (genomeName.length === genomeNameLength) {
        if (summary.find((k) => k.organism === organismName) !== undefined) {
          summary.find((k) => k.organism === organismName).count += organismCount;
        } else {
          summary.push({
            "name": genomeName,
            "length": genomeNameLength,
            "count": organismCount,
            "organism": organismName
          })
        }
      }
    }
  }

  let sorted = summary.sort((a, b) => b.count - a.count);

  for (let item of Object.keys(sorted)) {
    console.log(`${summary[item].organism} has genome size of ${summary[item].count}`);
  }
}

dNAex(['=12<<cat',
'!vi@rus?=2--142',
'?!cur##viba@cter!!=11--800<<cat',
'!fre?esia#=7--450<<mouse',
'@pa!rcuba@cteria$=13--351<<mouse',
'!richel#ia??=8--900<<human',
'Stop!'
]);