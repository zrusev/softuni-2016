namespace DWAsync
{
    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.IO;
    using System.Threading.Tasks;

    public class Program
    {
        private const string FOLDER_NAME = "Files";
        private const string RESULT_FOLDER_NAME = "Result Files";

        private static ConcurrentDictionary<string, byte[]> files = new ConcurrentDictionary<string, byte[]>();

        public static void Main()
            => Task.Run(async() => await MainAsync())
            .GetAwaiter()
            .GetResult();

        private static async Task MainAsync()
        {
            _ = Directory.CreateDirectory(RESULT_FOLDER_NAME);
            
            string filesDirectory = Path.Combine(Directory.GetCurrentDirectory(), FOLDER_NAME);
            DirectoryInfo directory = new DirectoryInfo(filesDirectory);

            await ReadAsync(directory);

            await WriteAsync();

            Console.WriteLine("Task Completed!");
        }

        private static Task ReadAsync(DirectoryInfo directory)
        {
            IList<Task> readTaskList = new List<Task>();

            FileInfo[] directoryFiles = directory.GetFiles();

            foreach (var file in directoryFiles)
            {
                readTaskList.Add(Task.Run(async() =>
                {
                    byte[] result;
                    using (FileStream SourceStream = File.Open(file.FullName, FileMode.Open, FileAccess.Read))
                    {
                        result = new byte[SourceStream.Length];

                        await SourceStream
                            .ReadAsync(result, 0, (int)SourceStream.Length);

                        var targetFolder = Path.Combine(Directory.GetCurrentDirectory(), RESULT_FOLDER_NAME);
                        var filePath = $"{targetFolder}\\{file.Name}";

                        //Approach One - read and write simultaneously into the same task
                        //await WriteAsync(filePath, result);

                        //or

                        //Approach Two - cache to internal collection and then write all at once
                        _ = files.TryAdd<string, byte[]>(filePath, result);
                    }
                }));
            }

            return Task.WhenAll(readTaskList);
        }

        private static Task WriteAsync(string filePath, byte[] text)
            => File.WriteAllBytesAsync(filePath, text);

        private static Task WriteAsync()
        {
            IList<Task> writeTaskList = new List<Task>();

            foreach (var file in files)
            {
                writeTaskList.Add(File.WriteAllBytesAsync(file.Key, file.Value));
            }

            return Task.WhenAll(writeTaskList);
        }
    }
}