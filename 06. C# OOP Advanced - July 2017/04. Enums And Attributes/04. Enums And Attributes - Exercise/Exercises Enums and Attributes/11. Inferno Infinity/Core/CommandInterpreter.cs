namespace _11.Inferno_Infinity.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Models;
    using Models.Weapons;

    public class CommandInterpreter
    {
        private readonly IList<Weapon> weapons;

        public CommandInterpreter()
        {
            this.weapons = new List<Weapon>();
        }

        public void Create(string weaponType, string name)
        {
            string[] weaponData = weaponType.Split();
            string type = weaponData[1];
            string rarity = weaponData[0];

            switch (type)
            {
                case "Axe":
                    this.weapons.Add(new Axe(name, rarity));
                    break;
                case "Knife":
                    this.weapons.Add(new Knife(name, rarity));
                    break;
                case "Sword":
                    this.weapons.Add(new Sword(name, rarity));
                    break;
                default:
                    break;
            }
        }

        public void Add(string weaponName, int socketIndex, string gemType)
        {
            this.GetWeaponByName(weaponName).AddGem(socketIndex, gemType);
        }

        public void Remove(string weaponName, int socketIndex)
        {
            this.GetWeaponByName(weaponName).RemoveGem(socketIndex);
        }

        public void Print(string weaponName)
        {
            Console.WriteLine(this.GetWeaponByName(weaponName));
        }

        private Weapon GetWeaponByName(string weaponName)
        {
            return this.weapons.FirstOrDefault(w => w.Name == weaponName);
        }
    }
}