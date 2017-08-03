namespace _11.Inferno_Infinity.Interfaces
{
    using Enums;

    public interface IGem
    {
        IStat Stat { get; }
        Clarity Clarity { get; }
    }
}