using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _06.Sentence_Extractor
{
    public class Sentence_Extractor
    {
        public static void Main()
        {
            var keyword = Console.ReadLine().Trim();
            var text = Console.ReadLine().Trim();

            var regex = new Regex($@"[^.?!]*(?<=[.?\s!]){keyword}[^.?!]*[.?!]");

            var results = regex.Matches(text);

            foreach (var result in results)
            {
                Console.WriteLine(result);
            }
        }
    }
}
