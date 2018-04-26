namespace StorageMaster.Core.IO
{
    using StorageMaster.Core.IO.Contracts;
    using System;

    public class ConsoleReader : IReader
	{
		public string ReadLine()
		{
			return Console.ReadLine();
		}
	}
}
