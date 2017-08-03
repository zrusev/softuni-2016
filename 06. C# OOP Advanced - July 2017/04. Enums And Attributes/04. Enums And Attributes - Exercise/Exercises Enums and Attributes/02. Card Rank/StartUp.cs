using System;
using System.Collections.Generic;

namespace _02.Card_Rank
{
    public class StartUp
    {
        public static void Main()
        {
            var input = Console.ReadLine();
            DeckOfCards deck = new DeckOfCards();
            for (int index = 0; index < 13; index++)
            {
                deck.AddToDeck(index.ToString());
            }
            
            Console.WriteLine(input + ":");

            foreach (var card in deck)
            {
                Console.WriteLine(card);
            }
        }
    }
}
