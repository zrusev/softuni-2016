using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Telephony
{
    public class Program
    {
        public static void Main()
        {
            string[] phoneNumbers = Console.ReadLine().Split();
            string[] sites = Console.ReadLine().Split();

            foreach (var item in phoneNumbers)
            {
                ISmartphone phone = new Smartphone(item);
                Console.WriteLine(phone.CallNumber(item));
            }

            foreach (var item in sites)
            {
                ISmartphone phone = new Smartphone(item);
                Console.WriteLine(phone.BrowserSite(item));
            }
        }
    }
}
