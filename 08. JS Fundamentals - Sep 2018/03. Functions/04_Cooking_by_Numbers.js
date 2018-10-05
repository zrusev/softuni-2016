function solve(input) {
    let number = +input[0];

    for(let i = 1; i < input.length; i++) {
        number = action(number, input[i]);
        console.log(number);
    }

    function action(number, action) {
        switch(action) {
            case 'chop' : return number / 2;
            case 'dice' : return Math.sqrt(number);
            case 'spice' : return ++number;
            case 'bake' : return number * 3;
            case 'fillet' : return number - 0.2 * number;
        }
    }
}

solve(['9', 'dice', 'spice', 'chop', 'bake', 'fillet']);