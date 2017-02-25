using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11.Convert_Speed
{
    class Program
    {
        static void Main(string[] args)
        {
            uint meters = UInt32.Parse(Console.ReadLine());
            byte hours = byte.Parse(Console.ReadLine());
            byte minutes = byte.Parse(Console.ReadLine());
            byte seconds = byte.Parse(Console.ReadLine());

            ushort time = (ushort)(hours * 3600 + minutes * 60 + seconds);

            float metersPerSec = (float)meters / time;
            float kilometersPerHour = ((float)meters / 1000) / ((float)time / 3600);
            float milesPerHour = ((float)meters / 1609) / ((float)time / 3600);

            Console.WriteLine("{0:0.#######}", metersPerSec);
            Console.WriteLine("{0:0.#######}", kilometersPerHour);
            Console.WriteLine("{0:0.#######}", milesPerHour);
        }
    }
}
