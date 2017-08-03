using System;
using System.Collections;

namespace _03.Card_Power
{
    public class Card :  IComparable<Card>
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

        public int CompareTo(Card other)
        {
            if (ReferenceEquals(this, other))
            {
                return 0;                
            }
            if (ReferenceEquals(null, other))
            {
                return 1;
            }
            var rankComparison = this.rank.CompareTo(other.rank);
            if (rankComparison != 0)
            {
                return rankComparison;
            }
            return this.suit.CompareTo(other.suit);
        }
    }
}