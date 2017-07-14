public class Rectangle : Shape
{
    private double height;
    private double width;

    public double Width
    {
        get { return this.width; }
        set { this.width = value; }
    }

    public double Height
    {
        get { return this.height; }
        set { this.height = value; }
    }

    public Rectangle(double height, double width)
    {
        this.Width = width;
        this.Height = height;
    }

    public override double CalculatePerimeter()
    {
        return  this.Height * 2  + this.Width * 2;
    }

    public override double CalculateArea()
    {
        return this.Height * this.Width;
    }

    public override string Draw()
    {
        return base.Draw() + "Rectangle";
    }
}        

