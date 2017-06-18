using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10.Predicate_Party_
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<int, int, bool> Length = (n, m) => n == m;
            
            var names = Console.ReadLine().Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries).ToList();
            var input = Console.ReadLine();

            while (!input.Equals("Party!"))
            {
                var command = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                switch (command[0])
                {
                    case "Double":
                        DoubleCommand(command[1],command[2], names, Length);
                        break;
                    case "Remove":
                        RemoveCommand(command[1], command[2], names, Length);
                        break;
                }

                input = Console.ReadLine();
            }
            if (names.Count == 0)
            {
                Console.WriteLine("Nobody is going to the party!");
                return;
            }

            Console.WriteLine($"{string.Join(", ", names)} are going to the party!");
        }

        private static List<string> RemoveCommand(string action, string stringPart, List<string> names, Func<int, int, bool> checkLength)
        {
            switch (action)
            {
                case "StartsWith":
                    for (int i = 0; i < names.Count; i++)
                    {
                        if (names[i].Substring(0, stringPart.Length).Equals(stringPart))
                        {
                            names.RemoveAt(i);
                            i--;
                        }
                    }
                    break;
                case "EndsWith":
                    for (int i = 0; i < names.Count; i++)
                    {
                        if (names[i].Substring(names[i].Length - stringPart.Length, stringPart.Length).Equals(stringPart))
                        {
                            names.RemoveAt(i);
                            i--;
                        }
                    }
                    break;
                case "Length":
                    for (int i = 0; i < names.Count; i++)
                    {
                        if (checkLength(names[i].Length, int.Parse(stringPart)) == true)
                        {
                            names.RemoveAt(i);
                            i--;
                        }
                    }
                    break;
            }
            return names;
        }

        private static List<string> DoubleCommand(string action, string stringPart, List<string> names, Func<int, int, bool> checkLength)
        {
            switch (action)
            {
                case "StartsWith":
                    for (int i = 0; i < names.Count; i++)
                    {
                        if (names[i].Substring(0, stringPart.Length).Equals(stringPart))
                        {
                            names.Insert(names.IndexOf(names[i]) + 1, names[i]);
                            i++;
                        }
                    }
                    break;
                case "EndsWith":
                    for (int i = 0; i < names.Count; i++)
                    {
                        if (names[i].Substring(names[i].Length - stringPart.Length, stringPart.Length).Equals(stringPart))
                        {
                            names.Insert(names.IndexOf(names[i]) + 1, names[i]);
                            i++;
                        }
                    }
                    break;
                case "Length":
                    for (int i = 0; i < names.Count; i++)
                    {
                        if (checkLength(names[i].Length, int.Parse(stringPart)) == true)
                        {
                            names.Insert(names.IndexOf(names[i]) + 1, names[i]);
                            i++;
                        }
                    }
                    break;
            }
            return names;
        }
    }
}
