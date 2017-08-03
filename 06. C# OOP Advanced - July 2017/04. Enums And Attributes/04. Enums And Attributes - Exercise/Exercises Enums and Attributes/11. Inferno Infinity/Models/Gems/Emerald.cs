namespace _11.Inferno_Infinity.Models.Gems
{
    public class Emerald : Gem
    {
        public Emerald(string clarity)
            : base(clarity)
        {
            this.Stat = new Stat(1, 4, 9);
            this.GetStatsBonus();
        }
    }
}