namespace DivideAndConquer
{
    using System;
    using System.IO;
    using System.Diagnostics;
    using System.Linq;
    using System.Threading.Tasks;

    public class Program
    {
        public static async Task Main()
        {
            // using var process = Process.GetCurrentProcess();
            // process.PriorityClass = ProcessPriorityClass.High;

            var path = @"..\..\..\..\..\MobyDick.txt";
            var hugePath = @"..\..\..\..\..\MobyDickHuge.txt";
            var splitParts = @"..\..\..\..\..\SplitParts.txt";

            //MakeHugeFile(path, hugePath, 250);

            var syncSearcher = new SyncFileSearcher(hugePath);
            var threadSearcher = new ThreadFileSearcher(hugePath);
            var asyncSearcher = new AsyncFileSearcher(hugePath);

            var timer = Stopwatch.StartNew();

            var result = syncSearcher.Search("Moby");

            Console.WriteLine($"Sync: {timer.Elapsed}");

            Console.WriteLine(result);

            timer = Stopwatch.StartNew();

            result = await asyncSearcher.Search("Moby");

            Console.WriteLine($"Async: {timer.Elapsed}");

            Console.WriteLine(result);

            timer = Stopwatch.StartNew();

            result = threadSearcher.Search("Moby");

            Console.WriteLine($"Threads: {timer.Elapsed}");

            Console.WriteLine(result);

            // Validate split words are correctly found.
            threadSearcher = new ThreadFileSearcher(splitParts);

            result = threadSearcher.Search("programming");

            if (result != 100)
            {
                throw new InvalidOperationException("Split parts are not correctly searched in the Threads solution!");
            }

            asyncSearcher = new AsyncFileSearcher(splitParts);

            result = await asyncSearcher.Search("programming");

            if (result != 100)
            {
                throw new InvalidOperationException("Split parts are not correctly searched in the Tasks solution!");
            }
        }

        private static void MakeHugeFile(string path, string hugePath, int totalCopies)
        {
            var content = File.ReadAllText(path);

            using var writer = new StreamWriter(hugePath, true);

            for (int i = 0; i < totalCopies; i++)
            {
                writer.Write(content);
            }
        }
    }
}
