using System;

namespace _07.Deck_of_Cards
{
    public class StartUp
    {
        public static void Main()
        {
            foreach (var suit in Enum.GetValues(typeof(CardSuits)))
            {
                foreach (var rank in Enum.GetValues(typeof(CardRanks)))
                {
                    Console.WriteLine($"{rank} of {suit}");
                }
            }
        }
    }
}
