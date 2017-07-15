public class WaterBender : Bender
{
    public WaterBender(string name, int power, double waterClarity) 
        : base(name, power)
    {
        this.WaterClarity = waterClarity;
    }

    private double waterClarity;

    public double WaterClarity
    {
        get { return this.waterClarity; }
        set { this.waterClarity = value; }
    }

    public override double GetPower()
    {
        return this.WaterClarity * this.Power;
    }

    public override string ToString() => $"{base.ToString()}, Water Clarity: {this.WaterClarity:f2}";
}