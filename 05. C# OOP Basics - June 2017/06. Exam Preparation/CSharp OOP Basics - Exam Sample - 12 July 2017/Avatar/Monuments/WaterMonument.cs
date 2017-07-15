public class WaterMonument : Monument
{
    public WaterMonument(string name, int waterAffinity) 
        : base(name)
    {
        this.WaterAffinity = waterAffinity;
    }

    private int waterAffinity;

    public int WaterAffinity
    {
        get { return this.waterAffinity; }
        set { this.waterAffinity = value; }
    }

    public override int GetAffinity()
    {
        return this.WaterAffinity;
    }

    public override string ToString() => $"{base.ToString()}, Water Affinity: {WaterAffinity}";
}