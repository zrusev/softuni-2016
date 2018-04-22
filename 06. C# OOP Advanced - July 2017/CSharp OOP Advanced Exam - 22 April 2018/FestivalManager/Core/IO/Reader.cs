namespace FestivalManager.Core.IO
{
    using FestivalManager.Core.IO.Contracts;
    using System;
    public class Reader:  IReader
	{
        public string ReadLine()
        {
            return Console.ReadLine();
        }
	}
}