namespace DivideAndConquer
{
    using System;
    using System.IO;

    public class SyncFileSearcher
    {
        private readonly string fileContent;

        public SyncFileSearcher(string filePath)
            => this.fileContent = File.ReadAllText(filePath);

        public int Search(string searchTerm)
        {
            var currentIndex = -1;
            var count = 0;

            while (true)
            {
                currentIndex = this.fileContent.IndexOf(
                    searchTerm, 
                    currentIndex + 1, 
                    StringComparison.InvariantCulture);

                if (currentIndex < 0)
                {
                    break;
                }

                count++;
            }

            return count;
        }
    }
}
