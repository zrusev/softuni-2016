namespace Forum.App.ViewModels
{
    using System.Collections.Generic;
    using System.Linq;
    public abstract class ContentViewModel
    {
        private const int lineLength = 37;
        public ContentViewModel(string text)
        {
            this.Content = this.GetLines(text);
        }
        public string[] Content { get; }

        private string[] GetLines(string text)
        {
            char[] contentChars = text.ToCharArray();

            ICollection<string> lines = new List<string>();

            for (int i = 0; i < contentChars.Length; i++)
            {
                char[] lineChars = contentChars.Skip(i).Take(lineLength).ToArray();
                string line = string.Join("", lineChars);
                lines.Add(line);
            }

            return lines.ToArray();
        }
    }
}
