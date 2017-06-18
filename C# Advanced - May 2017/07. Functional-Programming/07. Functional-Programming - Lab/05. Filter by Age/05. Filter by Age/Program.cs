using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace _05.Filter_by_Age
{
    class Program
    {
        static void Main(string[] args)
        {
            var lines = int.Parse(Console.ReadLine());
            var people = new Dictionary<string, int>();
            for (int i = 0; i < lines; i++)
            {
                var input = Console.ReadLine().Split(new string[] {", "}, StringSplitOptions.RemoveEmptyEntries);
                people.Add(input[0], int.Parse(input[1]));
            }
            var condition = Console.ReadLine();
            var age = int.Parse(Console.ReadLine());
            var format = Console.ReadLine();

            Func<int, bool> tester = CreateTester(condition, age);
            Action<KeyValuePair<string, int>> printer = CreatePrinter(format);

            InvokePrinter(people, tester, printer);
        }

        private static void InvokePrinter(Dictionary<string, int> people, Func<int, bool> tester, Action<KeyValuePair<string, int>> printer)
        {
            foreach (var person in people)
            {
                if (tester(person.Value))
                {
                    printer(person);
                }
            }
        }

        private static Action<KeyValuePair<string, int>> CreatePrinter(string format)
        {
            switch (format)
            {
                case "name age":
                    return p => Console.WriteLine($"{p.Key} - {p.Value}");
                case "name":
                    return p => Console.WriteLine($"{p.Key}");
                case "age":
                    return p => Console.WriteLine($"{p.Value}");
                default: return null;
            }
        }

        private static Func<int, bool> CreateTester(string condition, int age)
        {
            if (condition == "older")
            {
                return n => n >= age;
            }
            else
            {
                return n => n <= age;
            }
        }
    }
}
