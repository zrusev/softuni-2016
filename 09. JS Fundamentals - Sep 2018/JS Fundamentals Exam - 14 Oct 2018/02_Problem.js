function solve(input) {
  let totalCashInATM = 0;
  let cashMachine = [];

  for (let line of input) {
    //Report
    let lineLength = +line.length;

    if (lineLength === 1) {
      let banknote = line[0];
      let banknoteCount = cashMachine.filter((n) => n === banknote).length;

      console.log(`Service Report: Banknotes from ${banknote}$: ${banknoteCount}.`);

    } else if (lineLength === 2) {
      //Withdraw
      let accountBalance = +line[0];
      let moneyToWithdraw = +line[1];

      if (accountBalance < moneyToWithdraw) {
        console.log(`Not enough money in your account. Account balance: ${accountBalance}$.`);
        continue;
      }

      if (totalCashInATM < 0 || totalCashInATM < moneyToWithdraw) {
        console.log(`ATM machine is out of order!`);
        continue;
      }

      sortCashMachine(cashMachine);

      let calculator = moneyToWithdraw;

      for (let i = 0; i < cashMachine.length; i++) {
        let note = cashMachine[i];

        if (calculator - note >= 0) {
          cashMachine.splice(i, 1);
          calculator -= note;
        }

        if (calculator <= 0) {
          break;
        }
      }

      totalCashInATM -= moneyToWithdraw;

      console.log(`You get ${moneyToWithdraw}$. Account balance: ${accountBalance - moneyToWithdraw}$. Thank you!`);

    } else if (lineLength > 2) {
      //Insert
      let insertedCash = line.reduce((acc, cur) => {
        return acc + cur;
      }, 0)

      totalCashInATM += insertedCash;

      line.forEach((b) => {
        if (b > 0) {
          cashMachine.push(b);
        }
      })

      console.log(`Service Report: ${insertedCash}$ inserted. Current balance: ${totalCashInATM}$.`);
    }
  }

  function sortCashMachine(machine) {
    machine.sort((a, b) => b - a);
  }
}


solve([
  [20, 5, 100, 20, 1],
  [457, 25],
  [100],
  [10, 10, 5, 20, 50, 20, 10, 5, 2, 100, 20],
  [20, 85],
  [5000, 4500],
])