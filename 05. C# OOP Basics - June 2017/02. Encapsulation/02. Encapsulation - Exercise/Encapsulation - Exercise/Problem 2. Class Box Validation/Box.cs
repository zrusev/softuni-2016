using System;

public class Box
{
    private double length;
    private double width;
    private double height;

    public double Length
    {
        get { return this.length; }
        set {
            if (value < 0)
            {
                throw new ArgumentException("Length cannot be zero or negative.");
            }
            this.length = value;
        }
    }
    public double Width {
        get { return this.width; }
        set
        {
            if (value < 0)
            {
                throw new ArgumentException("Width cannot be zero or negative.");
            }
            this.width = value;
        }
    }
    public double Height {
        get { return this.height; }
        set
        {
            if (value < 0)
            {
                throw new ArgumentException("Height cannot be zero or negative.");
            }
            this.height = value;
        }
    }

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
