using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class StartUp
{
    public static void Main()
    {
        var value = Console.ReadLine();
        Box<string> box = new Box<string>(value);
        Console.WriteLine(box.ToString());
    }
}
