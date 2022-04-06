namespace FolderSync
{
    using System;
    using System.Collections.Concurrent;
    using System.IO;
    using System.Threading;

    public class QueueFolderSynchronizer
    {
        private readonly string source;
        private readonly string destination;

        private readonly ConcurrentQueue<Action> jobs;
        private readonly FileSystemWatcher watcher;

        private readonly int maxThreads;
        private Timer timer;
        private long currentJobs;

        public QueueFolderSynchronizer(string sourcePath, string destinationPath)
        {
            this.source = sourcePath;
            this.destination = destinationPath;

            this.jobs = new ConcurrentQueue<Action>();
            this.watcher = new FileSystemWatcher
            {
                Path = this.source
            };

            this.maxThreads = Environment.ProcessorCount / 2;
            this.currentJobs = 0;
        }

        private void InitializeTimer()
        {
            this.timer = new Timer(_ =>
            {
                if (Interlocked.Read(ref this.currentJobs) == this.maxThreads || this.jobs.IsEmpty)
                {
                    return;
                }

                Interlocked.Add(ref this.currentJobs, 1);

                ThreadPool.QueueUserWorkItem(_ =>
                {
                    while (this.jobs.TryDequeue(out var action))
                    {
                        try
                        {
                            action();
                        }
                        catch
                        {
                            this.jobs.Enqueue(action);
                        }
                    }

                    Interlocked.Add(ref this.currentJobs, -1);
                });
            }, null, 0, 1000);
        }

        public void Start()
        {
            this.InitializeWatcher();
            this.InitializeTimer();
        }

        public void Stop()
        {
            this.watcher.EnableRaisingEvents = false;
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
            this.watcher.Created += (obj, data) =>
            {
                this.jobs.Enqueue(() =>
                {
                    var path = Path.GetRelativePath(this.source, data.FullPath);
                    
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
            this.watcher.Renamed += (obj, data) =>
            {
                this.jobs.Enqueue(() =>
                {
                    var oldPath = Path.GetRelativePath(this.source, data.OldFullPath);
                    var newPath = Path.GetRelativePath(this.source, data.FullPath);

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
            this.watcher.Changed += (obj, data) =>
            {
                this.jobs.Enqueue(() =>
                {
                    var path = Path.GetRelativePath(this.source, data.FullPath);
    
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
            this.watcher.Deleted += (obj, data) =>
            {
                this.jobs.Enqueue(() =>
                {
                    var path = Path.GetRelativePath(this.source, data.FullPath);
                 
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
