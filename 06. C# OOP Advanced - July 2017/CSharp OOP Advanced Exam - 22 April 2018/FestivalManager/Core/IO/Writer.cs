namespace FestivalManager.Core.IO
{
    using FestivalManager.Core.IO.Contracts;
    using System;
    using System.Text;
    public class Writer : IWriter
    {
        public void Write(string contents)
        {
            Console.WriteLine(contents);
        }

        public void WriteLine(string contents)
        {
            Console.WriteLine(contents);
        }
    }
}
