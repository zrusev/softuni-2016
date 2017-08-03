namespace _11.Inferno_Infinity.Models
{
    using System;
    using Enums;
    using Interfaces;

    public class Gem : IGem
    {
        protected Gem(string clarity)
        {
            this.Clarity = (Clarity)Enum.Parse(typeof(Clarity), clarity);
        }

        public void GetStatsBonus()
        {
            this.Stat.Agility += (int)this.Clarity;
            this.Stat.Strength += (int)this.Clarity;
            this.Stat.Vitality += (int)this.Clarity;
        }

        public IStat Stat { get; protected set; }
        public Clarity Clarity { get; }
    }
}