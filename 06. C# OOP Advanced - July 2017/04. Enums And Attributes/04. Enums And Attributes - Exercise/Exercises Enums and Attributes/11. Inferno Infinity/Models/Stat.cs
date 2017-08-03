namespace _11.Inferno_Infinity.Models
{
    using Interfaces;

    public class Stat : IStat
    {
        public Stat(int strength, int agility, int vitality)
        {
            this.Strength = strength;
            this.Agility = agility;
            this.Vitality = vitality;
        }

        public int Strength { get; set; }
        public int Agility { get; set; }
        public int Vitality { get; set; }
    }
}