namespace Problem02
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    public class Problem02
    {
        public static void Main()
        {
            var listOfMessages = new List<string>();
            var listOfBroadcasts = new List<string>();
            while (true)    
            {
                var input = Console.ReadLine();

                if(input.Equals("Hornet is Green"))
                {
                    break;
                }

                var splitInput = input.Split(new string[] { " <-> " }, StringSplitOptions.None);


                //var regex = new Regex(@"(.*)(\s<->\s)(.*)");

                //var match = regex.Match(input);

                //if (match.Success)
                //{
                //var firstQuery = match.Groups[1].Value;
                //var secondQuery = match.Groups[3].Value;
                    var firstQuery = splitInput[0];
                    var secondQuery = splitInput[1];

                    if (IsDigitsOnly(firstQuery) && IsAllLettersOrDigits(secondQuery))
                    {
                        var reversedKey = Reverse(firstQuery);
                        var temp = reversedKey + " -> " + secondQuery;
                        listOfMessages.Add(temp);
                    }
                    else if (IsAllLettersOrDigits2(firstQuery) && IsAllLettersOrDigits(secondQuery))
                    {
                        var smallCapitalLetters = secondQuery;
                        var temp = TestCaps(smallCapitalLetters) + " -> " + firstQuery;
                        listOfBroadcasts.Add(temp);
                    }

                //}
                

                //if (match.Success)
                //{
                //    var reversedKey = Reverse(match.Groups[1].Value);
                //    var temp = reversedKey + " -> " + match.Groups[3];
                //    listOfMessages.Add(temp);
                //}

                //regex = new Regex(@"^([^0-9.]+)(\s<->\s)([A-Za-z0-9]+)$");

                //var match2 = regex.Match(input);
                //if (match2.Success)
                //{
                //    var smallCapitalLetters = match2.Groups[3].Value;
                //    var temp = SmallCaptl(smallCapitalLetters) + " -> " + match2.Groups[1];
                //    listOfBroadcasts.Add(temp);
                //}

            }

            Console.WriteLine("Broadcasts:");
            if (listOfBroadcasts.Count == 0)
            {
                Console.WriteLine("None");
            }
            else
            {
                foreach (var item in listOfBroadcasts)
                {
                    Console.WriteLine(item);
                }
            }

            Console.WriteLine("Messages:");
            if (listOfMessages.Count == 0)
            {
                Console.WriteLine("None");
            }
            else
            {

                foreach (var item in listOfMessages)
                {
                    Console.WriteLine(item);
                }
            }
        }

        public static string TestCaps(string str)
        {
            char[] carr = str.ToCharArray();
            for (int i = 0; i < carr.Length; i++)
            {
                if (char.IsLetter(carr[i]))
                {
                    carr[i] = char.IsUpper(carr[i]) ? char.ToLower(carr[i]) : char.ToUpper(carr[i]);
                }
            }
            str = new string(carr);
            return str;
        }

        private static string SmallCaptl(string s)
        {
            char[] charArray = s.ToCharArray();

            for (int i = 0; i < charArray.Length - 1; i++)
            {
                if (char.IsLower(charArray[i]))
                {
                    charArray[i] = char.ToUpper(charArray[i]);
                }
                else
                {
                    charArray[i] = char.ToLower(charArray[i]);
                }
            }
            return new string(charArray);
        }

        public static string Reverse(string s)
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }

        public static bool IsDigitsOnly(string str)
        {
            foreach (char c in str)
            {
                if (c < '0' || c > '9')
                    return false;
            }

            return true;
        }

        public static bool IsAllLettersOrDigits(string s)
        {
            foreach (char c in s)
            {
                if (!Char.IsLetterOrDigit(c))
                    return false;
            }
            return true;
        }
        public static bool IsAllLettersOrDigits2(string s)
        {
            foreach (char c in s)
            {
                if (Char.IsDigit(c))
                    return false;
            }
            return true;
        }
    }
}
