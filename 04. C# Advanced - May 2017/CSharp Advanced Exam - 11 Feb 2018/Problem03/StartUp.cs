using System.Text;
using System.Text.RegularExpressions;

namespace Problem03
{
    using System;
    public class StartUp
    {
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());

            var passBuilder = new StringBuilder();
            var builder = new StringBuilder();
            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine();
                builder.Append(input);
            }

            var pattern = @"(?:\{)([^\d]*?(?<nums1>\d{3,})[^\d]*?)(\})|(?:\[)([^\d]*?(?<nums1>\d{3,})[^\d]*?)(\])";

            var matches = Regex.Matches(builder.ToString(), pattern);
            
            foreach (Match match in matches)
            {
                var nums1 = match.Groups["nums1"].Value;
                var nums1Length = match.Length;

                if (nums1.Length % 3 == 1)
                {
                    continue;
                }

                var tempContainer = string.Empty;

                for (int i = 1; i <= nums1.Length; i++)
                {
                    tempContainer += nums1[i - 1];

                    if (i % 3 == 0)
                    {
                        var currentNumber = int.Parse(tempContainer) - nums1Length;
                        passBuilder.Append((char)currentNumber).ToString();
                        tempContainer = string.Empty;
                    }
                }                
            }

            Console.WriteLine(passBuilder.ToString());
        }
    }
}
