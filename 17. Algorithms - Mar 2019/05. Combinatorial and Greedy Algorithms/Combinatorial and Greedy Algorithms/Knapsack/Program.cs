namespace Knapsack
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        internal class Item
        {
            public double Weight { get; set; }

            public double Price { get; set; }
        }

        public static void Main()
        {
            var capacity = double.Parse(Console.ReadLine().Split(' ')[1]);
            var items = double.Parse(Console.ReadLine().Split(' ')[1]);

            var allItems = new List<Item>();

            for (int i = 0; i < items; i++)
            {
                var currentItem = Console.ReadLine().Split(" -> ");

                allItems.Add(new Item
                {
                    Price = double.Parse(currentItem[0]),
                    Weight = double.Parse(currentItem[1])
                });
            }

            allItems = allItems
                .OrderByDescending(i => i.Price / i.Weight)
                .ToList();

            var index = 0;
            var totalPrice = 0.0;

            while(capacity > 0 && index < allItems.Count)
            {
                var currentItem = allItems[index];
                var takenQuantity = Math.Min(capacity, currentItem.Weight);

                var percentageQuantity = takenQuantity / currentItem.Weight;

                totalPrice += percentageQuantity * currentItem.Price;
                capacity -= takenQuantity;
                
                index++;

                var percQuantity = percentageQuantity == 1 ? "100" : $"{percentageQuantity * 100:F2}";

                Console.WriteLine($"Take {percQuantity}% of item with price {currentItem.Price:F2} and weight {currentItem.Weight:F2}");
            }

            Console.WriteLine($"Total price: {totalPrice:F2}");
        }
    }
}