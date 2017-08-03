using System;

namespace _01.Card_Suit
{
    public class Color
    {
        private CardSuits color;

        public Color(string color)
        {
            this.color = (CardSuits)Enum.Parse(typeof(CardSuits), color);
        }

        public override string ToString()
        {
            return $"Ordinal value: {(int) this.color}; Name value: {this.color}";
        }
    }
}