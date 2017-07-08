namespace _05.Magic_exchangeable_words
{
    using System;
    using System.Collections.Generic;

    class Magic_exchangeable_words
    {
        static void Main()
        {
            var input = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            Console.WriteLine(CheckCompatibility(input[0], input[1]).ToString().ToLower());

        }

        public static bool CheckCompatibility(string a, string b)
        {

            char[] arrA = a.ToCharArray();
            char[] arrB = b.ToCharArray();
            var result = false;

            var dict = new Dictionary<int, char>();

            for (int i = 0; i < Math.Min(arrA.Length, arrB.Length); i++)
            {
                if (!dict.ContainsKey(arrA[i]))
                {
                    result = true;
                    dict.Add(arrA[i], arrB[i]);
                }
                else
                {
                    if (arrB[i].Equals(dict[arrA[i]]))
                    {
                        result = true;
                    }
                    else
                    {
                        result = false;
                        break;
                    }
                }
            }

            if (arrA.Length != arrB.Length)
            {
                for (int i = Math.Max(arrA.Length, arrB.Length) - 1; i > Math.Min(arrA.Length, arrB.Length) - 1; i--)
                {

                    if (arrA.Length > arrB.Length)
                    {
                        var letterResult = false;
                        for (int j = 0; j < Math.Min(arrA.Length, arrB.Length) - 1; j++)
                        {
                            if (arrA[j].Equals(arrA[i]))
                            {
                                letterResult = true;
                                break;
                            }
                        }

                        if (letterResult)
                        {
                            result = true;
                        }
                        else
                        {
                            result = false;
                            break;
                        }
                    }

                    else if(!dict.ContainsValue(arrB[i]))
                    {
                        result = false;
                        break;
                    }
                }
            }


            return result;
        } 
    }
}
