function solve(input) {
    let inputNumber = Array.from(input.toString()).map(Number);
    
    let getAvg = (arr) => arr.reduce((a,b) => a + b, 0) / arr.length;

    if (getAvg(inputNumber) > 5) {
        return console.log(inputNumber.join(''));
    }

    while (getAvg(inputNumber) <= 5) {
        inputNumber.push(9);
    }

    return console.log(inputNumber.join(''));
}

solve(101);