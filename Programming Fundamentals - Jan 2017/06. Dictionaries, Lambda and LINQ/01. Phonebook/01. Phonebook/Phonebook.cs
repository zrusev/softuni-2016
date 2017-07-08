namespace _01.Phonebook
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Phonebook
    {
        public static void Main()
        {
            var text = Console.ReadLine()
                .Split(' ')
                .ToArray();

            var phoneBook = new Dictionary<string, string>();

            while (!text[0].Equals("END"))
            {
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