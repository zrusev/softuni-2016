using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Problem_12.Str_Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            Regex regex = new Regex(@"Rotate\((\d+)\)"); // regex to get the degrees
            string rotationUserInput = Console.ReadLine();
            var match = regex.Match(rotationUserInput);

            int rotationAngle = 0;
            if (match.Success)
            {
                rotationAngle = int.Parse(match.Groups[1].Value) % 360; // eliminate the full rotations
            }

            List<string> entries = new List<string>();
            string input = Console.ReadLine();
            while (input.ToUpper() != "END") // read user input
            {
                entries.Add(input);
                input = Console.ReadLine();
            }

            var result = Rotate(entries, rotationAngle / 90); // rotate the user input
            foreach (var row in result) // print result
            {
                Console.WriteLine(string.Join("", row));
            }
        }

        static char[][] Rotate(List<string> entries, int times) // times equals rotationAngle / 90
        {
            var rows = entries.Count; // get the rows
            var cols = entries.Max(x => x.Length); // get the longest string

            for (int i = 0; i < entries.Count; i++)
            {
                entries[i] = entries[i] + new string(' ', cols - entries[i].Length); // increase the length of all strings, so it is equal to the longest (you can use LINQ if you want)
            }

            if (times % 2 == 0) // check if the rotation is 0 or 180 degrees
            {
                if (times == 2) // if the rotation is 180 degrees reverse the strings and their order in the list
                {
                    entries.Reverse();
                    entries = entries.Select(x => new string(x.Reverse().ToArray())).ToList();
                }

                char[][] result = new char[rows][]; // fill the array with the values from the list and return it
                for (int i = 0; i < result.Length; i++)
                {
                    result[i] = entries[i].ToCharArray();
                }

                return result;
            }
            else // the rotation is 90 or 270 degrees
            {
                char[][] result = new char[cols][]; // fill the array with the values from the list and return it

                for (int i = 0; i < cols; i++)
                {
                    result[i] = new char[rows];
                    for (int j = 0; j < rows; j++)
                    {
                        result[i][j] = entries[times == 3 ? j : rows - 1 - j][times == 3 ? cols - 1 - i : i]; // ternary operator used to determine the correct index
                    }
                }

                return result;
            }
        }
    }
}