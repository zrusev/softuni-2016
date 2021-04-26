namespace Prototype
{
    using System;
    using Entities.Concrete;
    
    public class StartUp
    {
        public static void Main()
        {
            SandwichMenu sandwichMenu = new SandwichMenu();

            sandwichMenu["BLT"] = new Sandwich("Wheat", "Bacon");
            sandwichMenu["Turkey"] = new Sandwich("Rye", "Turkey");
            
            Sandwich sandwich1 = sandwichMenu["BLT"].Clone() as Sandwich;
            Sandwich sandwich2 = sandwichMenu["Turkey"].Clone() as Sandwich;
        }
    }
}