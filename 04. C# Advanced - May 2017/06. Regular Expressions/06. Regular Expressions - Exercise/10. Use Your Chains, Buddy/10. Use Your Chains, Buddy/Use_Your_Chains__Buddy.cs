namespace _10.Use_Your_Chains__Buddy
{
    using System;
    using System.Text;
    using System.Text.RegularExpressions;
    class Use_Your_Chains__Buddy
    {
        public static void Main()
        {
            var input = Console.ReadLine();

            Regex regex = new Regex(@"<p>(.*?)<\/p>");
            MatchCollection matches = regex.Matches(input);

            foreach (Match match in matches)
            {
                var whiteSpaces = "[^a-z0-9]+";
                var reminder = match.Groups[1].Value;
                var replaced = Regex.Replace(reminder, whiteSpaces, " ");
                var pattern = @"\s+";
                replaced = Regex.Replace(replaced, pattern, " ");

                //var sb = new StringBuilder();
                foreach (var character in replaced)
                {
                    if (character >= 'a' && character <= 'm')
                    {
                        Console.Write((char)(character + 13));
                    }
                    else if (character >= 'n' && character <= 'z')
                    {
                        Console.Write((char)(character - 13));
                    }
                    else
                    {
                        Console.Write(character);
                    }
                }


                //Console.WriteLine(result);
            }
        }
    }
}
