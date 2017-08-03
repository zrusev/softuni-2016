namespace _11.Inferno_Infinity.Interfaces
{
    using Enums;
    using Models;

    public interface IWeapon
    {
        string Name { get; }
        int MinDamage { get; }
        int MaxDamage { get; }

        Rarity Rarity { get; }
        Gem[] Gems { get; }
    }
}