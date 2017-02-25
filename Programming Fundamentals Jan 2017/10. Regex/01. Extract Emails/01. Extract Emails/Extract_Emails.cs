namespace _01.Extract_Emails
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    class Extract_Emails
    {
        static void Main()
        {

            string text = Console.ReadLine();
            string pattern = @"\b(?<!\S)(([a-z0-9\-\.]+@[a-z0-9\-]+\.[a-z0-9]+([\.a-z0-9]+)?))\b";
            Regex regex = new Regex(pattern);

            var matches = regex.Matches(text);

            foreach (Match match in matches)
            {
                string matchString = match.ToString();

                if (
                    !(matchString.StartsWith("-")
                    || matchString.StartsWith("_")
                    || matchString.StartsWith(".")
                    || matchString.EndsWith("-")
                    || matchString.EndsWith("_")
                    || matchString.EndsWith("."))
                    )
                {
                    Console.WriteLine(match.Value);
                }
            }


        }
    }
}
