using System;
using System.Collections.Generic;
using _03.Card_Power;

namespace _04.Card_ToString
{
    public class StartUp
    {
        public static void Main()
        {
            var rank = Console.ReadLine();
            var suit = Console.ReadLine();

            Card card = new Card(rank, suit);
            Console.Write(card);
            Console.WriteLine(card.SumUp());
        }
    }
}
