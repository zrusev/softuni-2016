namespace FolderSync
{
    using System;
    using System.IO;
    using System.Threading;
    using System.Threading.Channels;

    public class ChannelFolderSynchronizer
    {
        private readonly string source;
        private readonly string destination;
        private readonly int maxThreads;

        private readonly FileSystemWatcher watcher;

        private readonly ChannelWriter<Action> jobsWriter;
        private readonly ChannelReader<Action> jobsReader;

        public ChannelFolderSynchronizer(string sourcePath, string destinationPath)
        {
            this.source = sourcePath;
            this.destination = destinationPath;

            var channel = Channel.CreateUnbounded<Action>();

            this.jobsWriter = channel.Writer;
            this.jobsReader = channel.Reader;

            this.watcher = new FileSystemWatcher
            {
                Path = this.source
            };

            this.maxThreads = Environment.ProcessorCount / 2;
        }

        public void Start()
        {
            this.InitializeWatcher();
            this.InitializeJobs();
        }

        private void InitializeJobs()
        {
            for (var i = 0; i < this.maxThreads; i++)
            {
                Thread thread = new Thread(async () =>
                {
                    while (await this.jobsReader.WaitToReadAsync())
                    {
                        var action = await this.jobsReader.ReadAsync();

                        try
                        {
                            action();
                        }
                        catch
                        {
                            await this.jobsWriter.WriteAsync(action);
                        }
                    }
                });

                thread.Start();
            }
        }

        public void Stop()
        {
            this.watcher.EnableRaisingEvents = false;
            this.jobsWriter.Complete();
        }

        private void InitializeWatcher()
        {
            this.InitializeCreatedEvent();
            this.InitializeRenamedEvent();
            this.InitializeChangedEvent();
            this.InitializeDeletedEvent();

            this.watcher.IncludeSubdirectories = true;
            this.watcher.EnableRaisingEvents = true;
        }

        private void InitializeCreatedEvent()
        {
            this.watcher.Created += async (obj, data) =>
            {
                var path = Path.GetRelativePath(this.source, data.FullPath);

                await this.jobsWriter.WriteAsync(() =>
                {
                    var destinationPath = Path.Combine(this.destination, path);

                    if (Directory.Exists(data.FullPath))
                    {
                        Directory.CreateDirectory(destinationPath);
                    }
                    else
                    {
                        File.Copy(data.FullPath, destinationPath);
                    }

                    Console.WriteLine($"Copied '{path}'.");
                });
            };
        }

        private void InitializeRenamedEvent()
        {
            this.watcher.Renamed += async (obj, data) =>
            {
                var oldPath = Path.GetRelativePath(this.source, data.OldFullPath);
                var newPath = Path.GetRelativePath(this.source, data.FullPath);

                await this.jobsWriter.WriteAsync(() =>
                {
                    var destinationOldPath = Path.Combine(this.destination, oldPath);
                    var destinationNewPath = Path.Combine(this.destination, newPath);

                    if (Directory.Exists(destinationOldPath))
                    {
                        Directory.Move(destinationOldPath, destinationNewPath);
                    }
                    else
                    {
                        File.Move(destinationOldPath, destinationNewPath);
                    }

                    Console.WriteLine($"Renamed '{oldPath}' to '{newPath}'.");
                });
            };
        }

        private void InitializeChangedEvent()
        {
            this.watcher.Changed += async (obj, data) =>
            {
                var path = Path.GetRelativePath(this.source, data.FullPath);

                await this.jobsWriter.WriteAsync(() =>
                {
                    var destinationPath = Path.Combine(this.destination, path);

                    if (!Directory.Exists(data.FullPath))
                    {
                        File.Copy(data.FullPath, destinationPath, true);

                        Console.WriteLine($"Updated '{path}'.");
                    }
                });
            };
        }

        private void InitializeDeletedEvent()
        {
            this.watcher.Deleted += async (obj, data) =>
            {
                var path = Path.GetRelativePath(this.source, data.FullPath);

                await this.jobsWriter.WriteAsync(() =>
                {
                    var destinationPath = Path.Combine(this.destination, path);

                    if (Directory.Exists(data.FullPath))
                    {
                        Directory.Delete(destinationPath);
                    }
                    else
                    {
                        File.Delete(destinationPath);
                    }

                    Console.WriteLine($"Deleted '{path}'.");
                });
            };
        }
    }
}
