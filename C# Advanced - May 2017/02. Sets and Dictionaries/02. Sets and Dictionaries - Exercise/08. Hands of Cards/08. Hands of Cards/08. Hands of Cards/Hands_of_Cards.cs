using System.Linq;

namespace _08.Hands_of_Cards
{
    using System;
    using System.Collections.Generic;
    public class Hands_of_Cards
    {
        public static void Main()
        {
            var dict = new Dictionary<string, string>();
            var line = string.Empty;
            var personName = string.Empty;
            var cards = string.Empty;

            while (true)
            {
                line = Console.ReadLine();

                if (line.Equals("JOKER", StringComparison.OrdinalIgnoreCase))
                {
                    break;
                }

                personName = line.Substring(0, line.IndexOf(':'));

                cards = line.Substring(line.IndexOf(':') + 2);
                if (!dict.ContainsKey(personName))
                {
                    dict.Add(personName, cards);
                }
                else
                {
                    dict[personName] = dict[personName] + ", " + cards;
                }

            }

            foreach (var card in dict)
            {
                var single = card.Value.Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries).Distinct();
                var currentResult = 0;
                foreach (var element in single)
                {

                    if (element.Length == 2)
                    {
                        var elementOne = (int)Char.GetNumericValue(element[0]);
                        if (Char.IsLetter(element[0]))
                        {
                            elementOne = (int)exChange(element[0]);
                        }

                        var elementTwo = (int)exChange(element[1]);

                        var result = elementOne * elementTwo;

                        currentResult += result;
                        //int tst0 = (int)Char.GetNumericValue(element[0]);
                        //var tst = (int)exChange(element[0]);
                        //var result = tst0 * (int)exChange(element[1]);

                    }
                    else
                    {
                        var elementOne = 10;
                        var elementTwo = (int)exChange(element[2]);
                        var result = elementOne * elementTwo;
                        currentResult += result;
                    }
                }
                Console.WriteLine($"{card.Key}: {currentResult}");
            }
        }
        static int exChange(char element)
        {
            switch (element)
            {
                case 'J':
                    element = (char)11;
                    break;
                case 'Q':
                    element = (char)12;
                    break;
                case 'K':
                    element = (char)13;
                    break;
                case 'A':
                    element = (char)14;
                    break;
                case 'S':
                    element = (char)4;
                    break;
                case 'H':
                    element = (char)3;
                    break;
                case 'D':
                    element = (char)2;
                    break;
                case 'C':
                    element = (char)1;
                    break;
            }
            return element;
        }
    }
}
