namespace _11.Inferno_Infinity.Models
{
    using System;
    using System.Linq;
    using Attributes;
    using Enums;
    using Gems;
    using Interfaces;

    [CustomClass("Pesho", 3, "Used for C# OOP Advanced Course - Enumerations and Attributes.", "Pesho", "Svetlio")]
    public class Weapon : IWeapon
    {
        protected Weapon(string name, string rarity, int sockets)
        {
            this.Name = name;
            this.Rarity = (Rarity)Enum.Parse(typeof(Rarity), rarity);
            this.Gems = new Gem[sockets];
            for (int i = 0; i < this.Gems.Length; i++)
            {
                this.Gems[i] = null;
            }
        }

        protected void GetRarityBonus()
        {
            this.MinDamage *= (int)this.Rarity;
            this.MaxDamage *= (int)this.Rarity;
        }

        public string Name { get; }
        public int MinDamage { get; set; }
        public int MaxDamage { get; set; }
        public Rarity Rarity { get; }
        public Gem[] Gems { get; set; }

        //this just before print!!!
        public void GetGemBonuses()
        {
            foreach (var gem in this.Gems.Where(g => g != null))
            {
                this.MinDamage += 1 * gem.Stat.Agility;
                this.MaxDamage += 4 * gem.Stat.Agility;
                this.MinDamage += 2 * gem.Stat.Strength;
                this.MaxDamage += 3 * gem.Stat.Strength;
            }
        }

        private int GetTotalStrength()
        {
            int strength = 0;

            foreach (var gem in this.Gems.Where(g => g != null))
            {
                strength += gem.Stat.Strength;
            }

            return strength;
        }

        private int GetTotalAgility()
        {
            int agility = 0;

            foreach (var gem in this.Gems.Where(g => g != null))
            {
                agility += gem.Stat.Agility;
            }

            return agility;
        }

        private int GetTotalVitality()
        {
            int vitalite = 0;

            foreach (var gem in this.Gems.Where(g => g != null))
            {
                vitalite += gem.Stat.Vitality;
            }

            return vitalite;
        }

        public override string ToString()
        {
            this.GetGemBonuses();
            return $"{this.Name}: {this.MinDamage}-{this.MaxDamage} Damage, +{this.GetTotalStrength()} Strength, " +
                   $"+{this.GetTotalAgility()} Agility, +{this.GetTotalVitality()} Vitality";
        }

        public void RemoveGem(int index)
        {
            if (index < this.Gems.Length)
            {
                this.Gems[index] = null;
            }
        }

        public void AddGem(int socketIndex, string gemType)
        {
            if (socketIndex < this.Gems.Length)
            {
                string[] gemData = gemType.Split();
                string type = gemData[1];
                string clarity = gemData[0];

                switch (type)
                {
                    case "Ruby":
                        this.Gems[socketIndex] = new Ruby(clarity);
                        break;
                    case "Amethyst":
                        this.Gems[socketIndex] = new Amethyst(clarity);
                        break;
                    case "Emerald":
                        this.Gems[socketIndex] = new Emerald(clarity);
                        break;
                }
            }
        }
    }
}