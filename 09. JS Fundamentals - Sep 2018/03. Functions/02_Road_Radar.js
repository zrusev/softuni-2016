function solve(input) {
    let speed = input[0];
    let zone = input[1];

    let limit = getLimit(zone);
    let inflaction = getInflaction(speed, limit);

    if (inflaction) {
        console.log(inflaction);
    }

    function getLimit(zone) {
        switch (zone) {
            case 'motorway' : return 130;
            case 'interstate' : return 90;
            case 'city' : return 50;
            case 'residential' : return 20;
        }
    }

    function getInflaction(speed, limit) {
        let overSpeed = speed - limit;

        if (overSpeed <= 0) {
            return false;
        } else if (overSpeed <= 20) {
            return 'speeding';
        } else if (overSpeed > 20 && overSpeed <= 40) {
            return 'excessive speeding';
        } else {
            return 'reckless driving';
        }
    }
}

solve([200, 'motorway']);