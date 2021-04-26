namespace Abstract_Factory
{
    using Factories.Abstract;
    using Factories.Concrete;
    using System;
    
    public class StartUp
    {
        public static void Main()
        {
            char input = 'A';
            RecipeFactory factory;
        
            switch(input)
            {
                case 'A':
                    factory = new AdultCuisineFactory();
                    break;

                case 'C':
                    factory = new KidCuisineFactory();
                    break;

                default:
                    throw new NotImplementedException();
            }

            var sandwich = factory.CreateSandwich();
            var dessert = factory.CreateDessert();

            Console.WriteLine(sandwich.GetType().Name);
        }
    }
}