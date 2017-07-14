using Problem_3.Wild_farm.Models;
using Problem_3.Wild_farm.Models.Foods;

namespace Problem_3.Wild_farm.Factories
{
    public class FoodFactory
    {
        public static Food GetFood(string[] tokens)
        {
            var foodType = tokens[0];
            var foodQuantity = int.Parse(tokens[1]);

            if (foodType == "Meat")
            {
                return new Meat(foodQuantity);
            }
            
            return new Vegitable(foodQuantity);
        }
    }
}