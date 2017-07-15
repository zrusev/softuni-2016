public class FireBender : Bender
{
    public FireBender(string name, int power, double heatAggression) 
        : base(name, power)
    {
        this.heatAggression = heatAggression;
    }

    private double heatAggression;

    public double HeatAggression
    {
        get { return this.heatAggression; }
        set { this.heatAggression = value; }
    }

    public override double GetPower()
    {
        return this.HeatAggression * this.Power;
    }

    public override string ToString() => $"{base.ToString()}, Heat Aggression: {this.HeatAggression:f2}";
}