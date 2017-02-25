namespace _07.AndreyAndBilliard
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class AndreyAndBilliard
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            var dict = new Dictionary<string, decimal>();

            for (int i = 0; i < n; i++)
            {

                var entities = Console.ReadLine().Split('-');
                if (!dict.ContainsKey(entities[0]))
                {
                    dict.Add(entities[0], decimal.Parse(entities[1]));
                }
                else
                {
                    dict[entities[0]] = decimal.Parse(entities[1]);
                }
            }

                var list = new ListOfOrders();
                list.List = new List<Customer>();

                while (true)
                {
                    var input = Console.ReadLine();

                    if (input.Equals("end of clients", StringComparison.OrdinalIgnoreCase))
                    {
                        break;
                    }
                    var client = new Customer();
                    client.ProductQuantity = new SortedDictionary<string, decimal>();
                    var clientOrder = input.Split('-', ',');

                    
                    if (dict.ContainsKey(clientOrder[1]))
                    {
                        client.CustomerName = clientOrder[0];
                        client.ProductQuantity.Add(clientOrder[1], decimal.Parse(clientOrder[2]));
                        list.List.Add(client);
                    }
                    
                }

            var newList = list.List
                .OrderBy(x => x.CustomerName);
            decimal totalBill = 0;
            foreach (var item in newList)
            {
                Console.WriteLine(item.CustomerName);
                Console.WriteLine($"-- {item.ProductQuantity.First().Key} - {item.ProductQuantity.First().Value}");
                Console.WriteLine($"Bill: {item.ProductQuantity.First().Value * dict[item.ProductQuantity.First().Key]:F2}");
                totalBill += item.ProductQuantity.First().Value * dict[item.ProductQuantity.First().Key];
            }
            Console.WriteLine($"Total bill: {totalBill:F2}");

        }
    }
}
