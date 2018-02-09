namespace Greedy_Times
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    public class StartUp
    {
        public static void Main()
        {
            var goldBasket = new Dictionary<string, long>();
            var gemBasket = new Dictionary<string, long>();
            var cashBasket = new Dictionary<string, long>();
            var currentBasket = new Dictionary<string, Dictionary<string, long>>();

            long currentBasketAmount = 0;

            var basketCapacity = long.Parse(Console.ReadLine());
            var input = Console.ReadLine().Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries).ToArray();

            for (int i = 0; i < input.Length; i += 2)
            {
                var currentItem = input[i];
                var currentAmount = long.Parse(input[i + 1]);

                var itemType = GetItemType(currentItem);

                if (currentBasketAmount + currentAmount > basketCapacity)
                {
                    continue;
                }

                var goldAmountAtAnyTime = goldBasket.Values.Sum();
                var gemAmountAtAnyTime = gemBasket.Values.Sum();
                var cashAmountAtAnyTime = cashBasket.Values.Sum();

                switch (itemType)
                {
                    case "Cash":
                        if (!CheckAmounts(goldAmountAtAnyTime, gemAmountAtAnyTime, cashAmountAtAnyTime + currentAmount))
                        {
                            continue;
                        }

                        AddToBasket(currentItem, currentAmount, cashBasket);
                        break;
                    case "Gold":
                        if (!CheckAmounts(goldAmountAtAnyTime + currentAmount, gemAmountAtAnyTime, cashAmountAtAnyTime))
                        {
                            continue;
                        }

                        AddToBasket(currentItem, currentAmount, goldBasket);
                        break;
                    case "Gem":
                        if (!CheckAmounts(goldAmountAtAnyTime, gemAmountAtAnyTime + currentAmount, cashAmountAtAnyTime))
                        {
                            continue;
                        }

                        AddToBasket(currentItem, currentAmount, gemBasket);
                        break;
                    default:
                        continue;
                }
                currentBasketAmount += currentAmount;
            }

            currentBasket.Add("Gold", goldBasket);
            currentBasket.Add("Gem", gemBasket);
            currentBasket.Add("Cash", cashBasket);

            foreach (var dict in currentBasket.OrderByDescending(c => c.Value.Values.Sum()))
            {
                if (dict.Value.Values.Sum() > 0)
                {
                    Console.WriteLine($"<{dict.Key}> ${dict.Value.Values.Sum()}");
                }

                foreach (var item in dict.Value.OrderByDescending(i => i.Key).ThenBy(i => i.Value))
                {
                    Console.WriteLine($"##{item.Key} - {item.Value}");
                }
            }
        }
        private static bool CheckAmounts(long goldAmountAtAnyTime, long gemAmountAtAnyTime, long cashAmountAtAnyTime)
        {
            return goldAmountAtAnyTime >= gemAmountAtAnyTime && gemAmountAtAnyTime >= cashAmountAtAnyTime;
        }
        private static void AddToBasket(string currentItem, long currentAmount, Dictionary<string, long> basket)
        {
            if (!basket.ContainsKey(currentItem))
            {
                basket.Add(currentItem, currentAmount);
            }
            else
            {
                basket[currentItem] += currentAmount;
            }
        }
        private static string GetItemType(string currentItem)
        {
            if (currentItem.Length == 3)
            {
                return "Cash";
            }

            if (currentItem.ToLower().Equals("gold"))
            {
                return "Gold";
            }

            if (currentItem.Substring(currentItem.Length - 3, 3).ToLower().Equals("gem") && currentItem.Length >= 4)
            {
                return "Gem";
            }

            return string.Empty;
        }
    }
}
