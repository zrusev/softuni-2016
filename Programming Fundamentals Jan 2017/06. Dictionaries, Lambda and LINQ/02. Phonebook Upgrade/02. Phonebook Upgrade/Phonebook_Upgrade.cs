namespace _02.Phonebook_Upgrade
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Phonebook_Upgrade
    {
        public static void Main()
        {
            var text = Console.ReadLine()
                .Split(' ')
                .ToArray();

            var phoneBook = new SortedDictionary<string, string>();

            while (!text[0].Equals("END"))
            {
                if (text[0].Equals("ListAll"))
                {
                    foreach (var element in phoneBook)
                    {
                        Console.WriteLine($"{element.Key} -> {element.Value}");
                    }
                }

                if (text[0].Equals("A"))
                {
                    phoneBook[text[1]] = text[2];
                }

                if (text[0].Equals("S"))
                {
                    if (phoneBook.ContainsKey(text[1]))
                    {
                        Console.WriteLine($"{text[1]} -> {phoneBook[text[1]]}");

                    }
                    else
                    {
                        Console.WriteLine($"Contact {text[1]} does not exist.");
                    }

                }

                text = Console.ReadLine()
                    .Split(' ')
                    .ToArray();
            }
        }
    }
}
