namespace _06.A_Miner_s_Task
{
    using System;
    using System.Collections.Generic;
    public class A_Miner_s_Task
    {
        public static void Main()
        {
            var dict = new Dictionary<string, int>();
            var resource = string.Empty;
            var quantity = 0;

            while (true)
            {
                resource = Console.ReadLine();

                if (resource.Equals("stop", StringComparison.OrdinalIgnoreCase))
                {
                    break;
                }

                quantity = int.Parse(Console.ReadLine());

                if (dict.ContainsKey(resource))
                {
                    quantity = quantity + dict[resource];
                    dict[resource] = quantity;
                }
                else
                {
                    dict.Add(resource, quantity);
                }


            }

            foreach (var el in dict)
            {
                Console.WriteLine($"{el.Key} -> {el.Value}");
            }

        }
    }
}
