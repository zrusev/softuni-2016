function solve(input) {
    let container = [];

    container.push(`<?xml version="1.0" encoding="UTF-8"?>\n<quiz>`);
    
    for(let i = 0; i < input.length; i += 2) {
        container.push(getQuestion(input[i]));
        container.push(getAnswer(input[i + 1]));
    }

    container.push(`\n</quiz>`);

    console.log(container.join(''));

    function getQuestion(question) {
        return `\n  <question>\n    ${question}\n  </question>`;
    }

    function getAnswer(answer) {
        return `\n  <answer>\n    ${answer}\n  </answer>`;
    }
}

solve(["Dry ice is a frozen form of which gas?",
"Carbon Dioxide",
"What is the brightest star in the night sky?",
"Sirius"]
);