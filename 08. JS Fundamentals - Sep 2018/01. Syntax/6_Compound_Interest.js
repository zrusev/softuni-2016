 function compound([p,i,n,t]) {
   console.log(p * Math.pow(1 + i/12/n, n * t));
 }

 compound([1500, 4.3, 3, 6]);