namespace Factory_Method
{
    using Entities.Concrete;
    using System;

    public class StartUp
    {
        public static void Main()
        {
            var turkeySandwich = new TurkeySandwich(); 
            
            Console.WriteLine($"Ingredients Count: {turkeySandwich.IngredientsCount}");
        }
    }
}
