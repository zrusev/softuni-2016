using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _19.Thea_The_Photogr
{
    class Program
    {
        static void Main(string[] args)
        {
            var pictures = int.Parse(Console.ReadLine());
            var filterTime = int.Parse(Console.ReadLine());
            var filterFactor = int.Parse(Console.ReadLine());
            var uploadTime = int.Parse(Console.ReadLine());
            var overallFilterTime = (long)pictures * filterTime;
            var filteredPictures = (long)Math.Ceiling((double)pictures * filterFactor / 100);
            var overallUploadTime = filteredPictures * uploadTime;
            var time = overallUploadTime + overallFilterTime;
            TimeSpan A = TimeSpan.FromSeconds(time);
            Console.WriteLine("{0:D1}:{1:D2}:{2:D2}:{3:D2}", A.Days, A.Hours, A.Minutes, A.Seconds);
        }
    }
}