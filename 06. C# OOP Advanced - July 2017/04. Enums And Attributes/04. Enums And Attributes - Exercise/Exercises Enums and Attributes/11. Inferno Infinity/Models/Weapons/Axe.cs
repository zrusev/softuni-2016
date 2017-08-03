namespace _11.Inferno_Infinity.Models.Weapons
{
    public class Axe : Weapon
    {
        public Axe(string name, string rarity)
            : base(name, rarity, 2)
        {
            //check if rarity 
            this.MaxDamage = 10;
            this.MinDamage = 5;
            this.GetRarityBonus();
        }

        public int Sockets { get; set; }
    }
}