namespace DivideAndConquer
{
    using System.IO;
    using System.Text.RegularExpressions;
    using System.Threading.Tasks;

    public class AsyncFileSearcher
    {
        private readonly string fileContent;

        public AsyncFileSearcher(string filePath)
            => this.fileContent = File.ReadAllText(filePath);

        public async Task<int> Search(string searchTerm)
        {

            return await Task<int>.Run(
                () => Regex.Matches(this.fileContent, searchTerm).Count);
        }
    }
}
