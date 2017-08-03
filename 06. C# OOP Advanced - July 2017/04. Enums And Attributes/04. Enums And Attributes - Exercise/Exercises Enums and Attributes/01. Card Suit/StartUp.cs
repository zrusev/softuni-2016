using System;
using System.Collections.Generic;

namespace _01.Card_Suit
{
    public class StartUp
    {
        public static void Main()
        {
            var input = Console.ReadLine();
            DeckOfCards deck = new DeckOfCards();

            for (int i = 0; i < 4; i++)
            {
                   deck.AddToDeck(i.ToString());
            }

            Console.WriteLine(input+":");
            foreach (var d in deck)
            {
                Console.WriteLine(d);
            }
        }
    }
}
