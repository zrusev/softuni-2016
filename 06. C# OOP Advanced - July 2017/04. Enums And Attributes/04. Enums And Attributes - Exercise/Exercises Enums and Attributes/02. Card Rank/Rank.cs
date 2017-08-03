using System;

namespace _02.Card_Rank
{
    public class Rank
    {
        private CardRanks rank;

        public Rank(string rank)
        {
            this.rank = (CardRanks)Enum.Parse(typeof(CardRanks), rank);
        }

        public override string ToString()
        {
            return $"Ordinal value: {(int) this.rank}; Name value: {this.rank}";
        }
    }
}