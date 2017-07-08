using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace _04.Special_Words
{
    public class Special_Words
    {
        public static void Main()
        {
            var dict = new Dictionary<string, int>();
            dict = Console.ReadLine().Split(new[] {'(', ')', '[', ']', '<', '>', '-', '!', '?', ' '},
                StringSplitOptions.RemoveEmptyEntries).ToDictionary(x => x, x => 0);

            var text = Console.ReadLine().Split(new[] { '(', ')', '[', ']', '<', '>', '-', '!', '?', ' ' },
                StringSplitOptions.RemoveEmptyEntries).ToArray();

            for (int i = 0; i < text.Length; i++)
            {
                if (dict.ContainsKey(text[i]))
                {
                    dict[text[i]]++;
                }
            }

            foreach (var kpv in dict)
            {
                Console.WriteLine($"{kpv.Key} - {kpv.Value}");
            }
        }
    }
}
