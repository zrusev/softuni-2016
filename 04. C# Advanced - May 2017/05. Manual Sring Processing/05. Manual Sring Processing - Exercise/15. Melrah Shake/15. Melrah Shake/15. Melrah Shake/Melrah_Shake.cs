using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _15.Melrah_Shake
{
    public class Melrah_Shake
    {
        public static void Main()
        {
            var text = Console.ReadLine();
            var pattern = Console.ReadLine();

            while (true)
            {
                int firstIndex = text.IndexOf(pattern);
                int lastIndex = text.LastIndexOf(pattern);

                if (firstIndex == -1 || firstIndex == lastIndex)
                {
                    break;
                }

                text = text.Remove(lastIndex, pattern.Length);
                text = text.Remove(firstIndex, pattern.Length);
                Console.WriteLine("Shaked it.");

                if (pattern.Length <= 1)
                    break;
                
                pattern = pattern.Remove(pattern.Length / 2, 1);
                
            }

            Console.WriteLine("No shake." + Environment.NewLine + text);


        }
    }
}
