using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _04.Replace_a_tag
{
    public class Replace_a_tag
    {
        public static void Main(string[] args)
        {
            var input = Console.ReadLine();

            var sb = new StringBuilder();

            while (input != "end")
            {
                sb.AppendLine(input);
                input = Console.ReadLine();
            }

            var text = sb.ToString();
            var pattern = @"<a (href=.+?)>(.+)<\/a>";

            var replaced = Regex.Replace(text, pattern, m => $"[URL {m.Groups[1]}]{m.Groups[2]}[/URL]");

            Console.WriteLine(replaced);
        }
    }
}
