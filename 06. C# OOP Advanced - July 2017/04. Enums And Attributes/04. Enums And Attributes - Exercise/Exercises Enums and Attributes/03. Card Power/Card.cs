using System;
using System.Collections;

namespace _03.Card_Power
{
    public class Card
    {
        private Rank rank;
        private Suit suit;

        public Card(string rank, string suit)
        {
            this.rank = (Rank) Enum.Parse(typeof(Rank), rank);
            this.suit = (Suit) Enum.Parse(typeof(Suit), suit);
        }

        public int SumUp()
        {
            return (int) this.rank + (int) this.suit;
        }

        public override string ToString()
        {
            return $"Card name: {this.rank} of {this.suit}; Card power: ";
        }
    }
}