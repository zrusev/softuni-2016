using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _04.Jedi_Dreams
{
    class Program
    {
        public static void Main()
        {
            var methods = new Dictionary<string, List<string>>();
            var lines = int.Parse(Console.ReadLine().Trim());
            var currentMethod = "";
            var haveDeclaredMethod = false;

            for (int i = 0; i < lines; i++)
            {
                var line = Console.ReadLine().Trim();
                var methodDeclaration = Regex.Match(line, @"static\s.*\s([A-Z][a-zA-Z]*)\s*\(.*\)$");
                if (methodDeclaration.Success)
                {
                    currentMethod = methodDeclaration.Groups[1].Value;
                    methods[currentMethod] = new List<string>();
                    haveDeclaredMethod = true;
                    continue;
                }
                if (haveDeclaredMethod)
                {
                    var invokedMethods = Regex.Matches(line, @"([A-Z][a-zA-Z]*)\s*\(");
                    if (invokedMethods.Count > 0)
                    {
                        foreach (Match method in invokedMethods)
                        {
                            methods[currentMethod].Add(method.Groups[1].Value);
                        }
                    }
                }

            }

            foreach (var declaratedMethod in methods.OrderByDescending(m => m.Value.Count).ThenBy(m => m.Key))
            {
                if (declaratedMethod.Value.Count > 0)
                {
                    Console.WriteLine(
                        $"{declaratedMethod.Key} -> {declaratedMethod.Value.Count} -> {string.Join(", ", declaratedMethod.Value.OrderBy(n => n))}");
                }
                else
                {
                    Console.WriteLine($"{declaratedMethod.Key} -> None");
                }
            }
        }
    }
}