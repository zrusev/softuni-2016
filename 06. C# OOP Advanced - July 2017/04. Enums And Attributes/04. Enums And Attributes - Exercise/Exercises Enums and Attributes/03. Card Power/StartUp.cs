using System;
using System.Collections.Generic;

namespace _03.Card_Power
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
