using System.Collections;
using System.Collections.Generic;

namespace _02.Card_Rank
{
    public class DeckOfCards : IEnumerable<Rank>
    {
        private readonly IList<Rank> deckOfCards;

        public DeckOfCards()
        {
            this.deckOfCards = new List<Rank>();
        }

        public void AddToDeck(string rank)
        {
            this.deckOfCards.Add(new Rank(rank));
        }

        public IEnumerator<Rank> GetEnumerator()
        {
            return this.deckOfCards.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}