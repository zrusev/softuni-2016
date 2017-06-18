using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11.Party_Reser_Filter
{
    class Program
    {
        static void Main(string[] args)
        {

            var people = Console.ReadLine().Split().ToList();

            var input = Console.ReadLine();

            var criteriaString = new List<string>();
            while (!input.Equals("Print"))
            {
                var commands = input.Split(';').ToList();
                var mainCommand = commands[0];
                var criteria = commands[1];
                var filterString = commands[2];

                switch (mainCommand)
                {
                    case "Add filter":
                        criteriaString.Add($"{criteria}\\{filterString}");
                        break;

                    case "Remove filter":
                        criteriaString.Remove($"{criteria}\\{filterString}");
                        break;
                }

                input = Console.ReadLine();
            }

            foreach (var item in criteriaString)
            {
                var comands = item.Split('\\').ToList();
                Predicate<string> filter = ReservationFilterPeople(comands[0], comands[1]);
                people.RemoveAll(filter);
            }

            Console.WriteLine(people.Count == 0 ? "" : string.Join(" ", people));
        }

        public static Predicate<string> ReservationFilterPeople(string criteria, string filterString)
        {
            switch (criteria)
            {
                case "Starts with":
                    return n => n.StartsWith(filterString);

                case "Ends with":
                    return n => n.EndsWith(filterString);

                case "Length":
                    return n => n.Length == int.Parse(filterString);

                case "Contains":
                    return n => n.Contains(filterString);
            }
            return null;
        }

        /////////////////////////////////////////////////////60 POINTS/////////////////////////////////////////////////////////////
        //    Func<int, int, bool> Length = (n, m) => n == m;
        //    var dict = new Dictionary<string, List<string>>();

        //    var names = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();
        //    var input = Console.ReadLine();
        //    var tmp = string.Empty;

        //    while (!input.Equals("Print"))
        //    {
        //        var command = input.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);

        //        switch (command[0])
        //        {
        //            case "Add filter":
        //                tmp = string.Join(";", command.Skip(1));
        //                dict.Add(tmp, names.ToList());
        //                RemoveCommand(command[1], command[2], names, Length);
        //                break;
        //            case "Remove filter":
        //                tmp = string.Join(";", command.Skip(1));
        //                names = dict[tmp];
        //                break;
        //        }

        //        input = Console.ReadLine();
        //    }
        //    if (names.Count == 0)
        //    {
        //        Console.WriteLine("Nobody is going to the party!");
        //        return;
        //    }

        //    Console.WriteLine(names.Count == 0 ? "": string.Join(" ", names));
        //}

        //private static List<string> RemoveCommand(string action, string stringPart, List<string> names, Func<int, int, bool> checkLength)
        //{
        //    switch (action)
        //    {
        //        case "Starts with":
        //            for (int i = 0; i < names.Count; i++)
        //            {
        //                if (names[i].Substring(0, stringPart.Length).Equals(stringPart))
        //                {
        //                    names.RemoveAt(i);
        //                    i--;
        //                }
        //            }
        //            break;
        //        case "Ends with":
        //            for (int i = 0; i < names.Count; i++)
        //            {
        //                if (names[i].Substring(names[i].Length - stringPart.Length, stringPart.Length).Equals(stringPart))
        //                {
        //                    names.RemoveAt(i);
        //                    i--;
        //                }
        //            }
        //            break;
        //        case "Length":
        //            for (int i = 0; i < names.Count; i++)
        //            {
        //                if (names[i].Length == int.Parse(stringPart))
        //                {
        //                    names.RemoveAt(i);
        //                    i--;
        //                }
        //            }
        //            break;
        //        case "Contains":
        //            for (int i = 0; i < names.Count; i++)
        //            {
        //                if (names[i].Contains(stringPart))
        //                {
        //                    names.RemoveAt(i);
        //                    i--;
        //                }
        //            }
        //            break;
        //    }
        //    return names;
        //}
        /////////////////////////////////////////////////////60 POINTS/////////////////////////////////////////////////////////////
    }
}
