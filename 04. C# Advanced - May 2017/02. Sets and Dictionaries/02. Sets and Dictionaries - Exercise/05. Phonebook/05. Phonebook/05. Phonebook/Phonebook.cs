namespace _05.Phonebook
{
    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;
    public class Phonebook
    {
        public static void Main()
        {
            var parts = Console.ReadLine().Split('-');
            var dict = new Dictionary<string, string>();

            while (parts[0] != "search")
            {

                if (!dict.ContainsKey(parts[0]))
                {
                    dict.Add(parts[0], parts[1]);
                }
                else
                {
                    dict[parts[0]] = parts[1];
                }

                parts = Console.ReadLine().Split('-');
            }

            var input = Console.ReadLine();

            while (input != "stop")
            {
                if (dict.ContainsKey(input))
                {
                    Console.WriteLine($"{input} -> {dict[input]}");
                }
                else
                {
                    Console.WriteLine($"Contact {input} does not exist.");
                }

                input = Console.ReadLine();
            }

        }
    }
}
