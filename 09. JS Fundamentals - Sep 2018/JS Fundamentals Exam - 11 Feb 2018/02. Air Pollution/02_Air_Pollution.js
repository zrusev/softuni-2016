function solve(rows, commands) {
    const breezeDrop = 15;
    const galeDrop = 20;
    let matrix = [];
    rows.forEach((row, i) => {
        matrix.push(row.split(' ').map(Number));
    });

    let commandExecuter = {
        breeze: (rowIndex) => breeze(rowIndex),
        gale: (colIndex) => gale(colIndex),
        smog: (value) => smog(value)
    };

    for(let row of commands) {
        let [command, num] = row.split(' ');
        num = +num;

        commandExecuter[command](num);
    }

    let pollutedAreas = [];
    matrix.forEach((row, i) => {
        row.forEach((el, j) => {
            if (el >= 50) {
                pollutedAreas.push(`[${i}-${j}]`);
            }
        })
    });

    if (pollutedAreas.length > 0) {
        console.log(`Polluted areas: ${pollutedAreas.join(', ')}`);
    } else {
        console.log('No polluted areas');
    }

    function breeze(rowIndex) {
        let matrixRow = matrix[rowIndex];
        for(let i = 0; i < matrixRow.length; i++) {
            matrixRow[i] = Math.max(0, matrixRow[i] - breezeDrop);
        }
    }
    
    function gale(colIndex) {
        for(let i = 0; i < matrix.length; i++) {
            matrix[i][colIndex] = Math.max(0, matrix[i][colIndex] - galeDrop);
        }
    }

    function smog(value) {
        for(let i = 0; i < matrix.length; i++) {
            for(let j = 0; j < matrix[i].length; j++) {
                matrix[i][j] += value;
            }
        }
    }
}
