using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Problem_1.Class_Box
{
    public class StartUp
    {
        public static void Main()
        {
            Type boxType = typeof(Box);
            FieldInfo[] fields = boxType.GetFields(BindingFlags.NonPublic | BindingFlags.Instance);
            Console.WriteLine(fields.Count());

            var box = new Box();            
            box.Length = double.Parse(Console.ReadLine());
            box.Width = double.Parse(Console.ReadLine());
            box.Height = double.Parse(Console.ReadLine());

            Console.WriteLine($"Surface Area - {box.SurfaceArea():f2}");
            Console.WriteLine($"Lateral Surface Area - {box.LateralSurfaceArea():f2}");
            Console.WriteLine($"Volume - { box.Volume():f2}");
        }
    }
}
