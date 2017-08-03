using System.Collections;
using System.Collections.Generic;

namespace _01.Card_Suit
{
    public class DeckOfCards : IEnumerable<Color>
    {
        private readonly IList<Color> listOfDecks; 

        public DeckOfCards()
        {
            this.listOfDecks = new List<Color>();
        }

        public void AddToDeck(string deck)
        {
            this.listOfDecks.Add(new Color(deck));
        }

        public IEnumerator<Color> GetEnumerator()
        {
            return this.listOfDecks.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}