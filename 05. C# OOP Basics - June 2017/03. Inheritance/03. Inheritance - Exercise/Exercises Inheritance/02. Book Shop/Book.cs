using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace _02.Book_Shop
{
    public class Book
    {
        private string title;
        private string author;
        protected decimal price;

        public Book(string author, string title, decimal price)
        {
            this.Author = author;
            this.Title = title;
            this.Price = price;
        }

        public virtual decimal Price
        {
            get { return this.price; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Price not valid!");
                }
                this.price = value;
            }
        }

        public string Author
        {
            get { return this.author; }
            set
            {
                //var tokens = value.Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);
                //Console.WriteLine($"{tokens[0]} - {tokens[1]}");

                var regex = new Regex(@" \d");
                if (regex.IsMatch(value))
                {                                  
                    throw new ArgumentException("Author not valid!");
                }
                this.author = value;
            }
        }

        public string Title
        {
            get { return this.title; }
            set
            {
                if (value.Length < 3)
                {
                    throw new ArgumentException("Title not valid!");
                }
                this.title = value;
            }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("Type: ").AppendLine(this.GetType().Name)
                .Append("Title: ").AppendLine(this.Title)
                .Append("Author: ").AppendLine(this.Author)
                .Append("Price: ").Append($"{this.Price:f1}")
                .AppendLine();

            return sb.ToString();
        }

    }
}
