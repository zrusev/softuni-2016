namespace Problem10
{
    using System;
    using System.Text;
    using System.Text.RegularExpressions;

    public class StartUp
    {
        public static void Main()
        {
            var input = Console.ReadLine();
            var pattern = @"(?:<p>)(?<txt>.+?)(?:<\/p>)";

            var matches = Regex.Matches(input, pattern);
            var currentMatch = string.Empty;

            foreach (Match match in matches)
            {
                currentMatch += match.Groups["txt"].Value;
            }

            currentMatch = Regex.Replace(currentMatch, @"[^a-z\d]", " ");
            currentMatch = Regex.Replace(currentMatch, @"\s+|\n+", " ");

            var result = new StringBuilder(currentMatch.Length);
            foreach (var ch in currentMatch)
            {
                if (ch >= 'a' && ch <= 'm')
                {
                    result.Append((char) (ch + 13));
                }
                else if (ch >= 'n' && ch <= 'z')
                {
                    result.Append((char) (ch - 13));
                }
                else
                {
                    result.Append(ch);
                }
            }

            Console.WriteLine(result);
        }
    }
}