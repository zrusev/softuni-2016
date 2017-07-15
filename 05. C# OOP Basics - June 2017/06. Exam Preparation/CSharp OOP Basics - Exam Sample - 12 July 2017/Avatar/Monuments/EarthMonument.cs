public class EarthMonument : Monument
{
    public EarthMonument(string name, int earthAffinity) 
        : base(name)
    {
        this.EarthAffinity = earthAffinity;
    }

    private int earthAffinity;

    public int EarthAffinity
    {
        get { return this.earthAffinity; }
        set { this.earthAffinity = value; }
    }

    public override int GetAffinity()
    {
        return this.EarthAffinity;
    }

    public override string ToString() => $"{base.ToString()}, Earth Affinity: {EarthAffinity}";
}