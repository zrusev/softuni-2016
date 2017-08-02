using System;
using System.Collections.Generic;

public class CoffeeMachine
{
    public IEnumerable<CoffeeType> CoffeesSold
    {
        get
        {
            return this.coffeeSold;
        }
    }
    private int coins;
    private IList<CoffeeType> coffeeSold;

    public CoffeeMachine()
    {
        this.coffeeSold = new List<CoffeeType>();
    }

    public void BuyCoffee(string size, string type)
    {
        CoffeePrice coffeePrice = (CoffeePrice) Enum.Parse(typeof(CoffeePrice), size);
        CoffeeType coffeeType = (CoffeeType) Enum.Parse(typeof(CoffeeType), type);

        if (this.coins >= (int)coffeePrice)
        {
            this.coffeeSold.Add(coffeeType);
            this.coins = 0;
        }
    }

    public void InsertCoin(string coin)
    {
        Coin rem = (Coin)Enum.Parse(typeof(Coin), coin);
        this.coins += (int) rem;
    }
}