namespace DivideAndConquer
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text.RegularExpressions;
    using System.Threading;

    public class ThreadFileSearcher
    {
        private readonly string fileContent;

        public ThreadFileSearcher(string filePath)
            => this.fileContent = File.ReadAllText(filePath);

        public int Search(string searchTerm)
        {
            int result = 0;
            int maxThreads = (int)Math.Ceiling((double)searchTerm.Length / Environment.ProcessorCount);
            var countdown = new CountdownEvent(maxThreads);

            var parts = this.Split(this.fileContent, maxThreads);
            
            for (int i = 0; i < parts.Count(); i++)
            {
                var current = i;

                new Thread(() =>
                {
                    var treadCount = 0;

                    treadCount += DoWork(parts[current], searchTerm);

                    Interlocked.Add(ref result, treadCount);

                    countdown.Signal();
                })
                {
                    Priority = ThreadPriority.Highest
                }
                .Start();
            }
            countdown.Wait();

            return result;
        }

        private IList<string> Split(string str, int chunkSize)
        {
            List<string> result = new List<string>();

            for (int i = 0; i < str.Length; i += str.Length / chunkSize + 1)
            {
                var startIndex = i;
                var endIndex = i + str.Length / chunkSize;

                if (endIndex > str.Length - 1)
                {
                    endIndex = str.Length - i;
                }

                result.Add(str.Substring(startIndex, endIndex));
            }

            return result;
        }
        private int DoWork(string str, string searchTerm)
        {
            return Regex.Matches(str, searchTerm).Count;
        }
    }
}
