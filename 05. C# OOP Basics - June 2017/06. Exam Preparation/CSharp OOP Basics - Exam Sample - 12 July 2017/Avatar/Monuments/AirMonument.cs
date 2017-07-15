public class AirMonument : Monument
{
    public AirMonument(string name, int airAffinity) 
        : base(name)
    {
        this.AirAffinity = airAffinity;
    }

    private int airAffinity;

    public int AirAffinity
    {
        get { return this.airAffinity; }
        set { this.airAffinity = value; }
    }

    public override int GetAffinity()
    {
        return this.AirAffinity;
    }

    public override string ToString() => $"{base.ToString()}, Air Affinity: {AirAffinity}";
}