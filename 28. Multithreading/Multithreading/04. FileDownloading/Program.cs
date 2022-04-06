namespace FileDownloading
{
    using System.IO;

    public class Program
    {
        public static void Main()
        {
            var lines = File.ReadAllLines(@"..\..\..\..\..\Files.txt");

            var fileDownloader = new AsyncFileDownloader(lines);

            fileDownloader.Download();
        }
    }
}
