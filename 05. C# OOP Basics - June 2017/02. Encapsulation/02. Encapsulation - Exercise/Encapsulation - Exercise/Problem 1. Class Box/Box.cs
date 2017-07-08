public class Box
{
    private double length;
    private double width;
    private double height;

    public double Length { get => length; set => length = value; }
    public double Width { get => width; set => width = value; }
    public double Height { get => height; set => height = value; }

    public double SurfaceArea()
    {
        return 2 * this.length * this.width + 2 * this.Length * this.height + 2 * this.width * this.height;
    }

    public double LateralSurfaceArea()
    {
        return 2 * this.length * this.height + 2 * this.width * this.height;
    }

    public double Volume()
    {
        return this.length * this.height * this.width;
    }
}
