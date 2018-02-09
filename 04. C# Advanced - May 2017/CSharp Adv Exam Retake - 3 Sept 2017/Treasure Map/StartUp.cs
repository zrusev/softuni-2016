namespace Treasure_Map
{
    using System;
    using System.Text.RegularExpressions;
    public class StartUp
    {
        public static void Main()
        {
            var pattern =
                @"(#|!)[^#!]*?(?<![a-zA-Z0-9])(?<streetName>[a-zA-Z]{4})(?![a-zA-Z0-9])[^#!]*(?<!\d)(?<streetNumber>\d{3})-(?<password>\d{4}|\d{6})(?!\d)[^#!]*?(#|!)";

            var n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine();

                var matches = Regex.Matches(input, pattern);

                var correctMatch = matches[matches.Count / 2];

                var streetName = correctMatch.Groups["streetName"].Value;
                var streetNumber = correctMatch.Groups["streetNumber"].Value;
                var streetPassword = correctMatch.Groups["password"].Value;

                Console.WriteLine($"Go to str. {streetName} {streetNumber}. Secret pass: {streetPassword}.");
            }
        }
    }
}
