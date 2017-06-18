using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11.Palindromes
{
    public class Palindromes
    {
        public static void Main(string[] args)
        {
            var line = Console.ReadLine().Split(new[] {' ', ',', '.', '?', '!'}, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            var list = new SortedSet<string>();
            for (int i = 0; i < line.Length; i++)
            {
                var temp = line[i];
                var first = line[i].Substring(0, line[i].Length / 2);
                var second = ReverseString(line[i]).Substring(0, line[i].Length / 2);

                if (first.Equals(second))
                {
                    list.Add(line[i]);
                }
            }
             
            Console.Write("[");
            Console.Write(string.Join(", ", list));
            Console.Write("]");
        }

        public static string ReverseString(string s)
        {
            char[] arr = s.ToCharArray();
            Array.Reverse(arr);
            return new string(arr);
        }
    }
}
