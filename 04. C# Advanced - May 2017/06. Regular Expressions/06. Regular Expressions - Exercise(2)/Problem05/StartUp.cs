namespace Problem05
{
    using System;
    using System.Text.RegularExpressions;
    public class StartUp
    {
        public static void Main()
        {
            var pattern = @"\b(?<![\.\-_])(?<user>[a-zA-Z0-9]+[\.\-_]?[a-zA-Z0-9]+)(?<separator>@)(?<host>[a-zA-Z-\.]+[\.][a-zA-Z]+)\b";
            var input = Console.ReadLine();

            var matches = Regex.Matches(input, pattern);

            foreach (Match match in matches)
            {
                Console.WriteLine(match.Value);
            }                

        }
    }
}
