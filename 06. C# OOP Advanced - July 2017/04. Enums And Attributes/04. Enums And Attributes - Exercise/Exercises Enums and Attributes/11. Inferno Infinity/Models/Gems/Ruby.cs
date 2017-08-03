namespace _11.Inferno_Infinity.Models.Gems
{
    public class Ruby : Gem
    {
        public Ruby(string clarity)
            : base(clarity)
        {
            this.Stat = new Stat(7, 2, 5);
            this.GetStatsBonus();
        }
    }
}