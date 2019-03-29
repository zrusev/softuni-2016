namespace BookShop
{
    using Data;
    using Microsoft.EntityFrameworkCore;
    using Z.EntityFramework.Plus;
    using Models.Enums;
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Text;
    using BookShop.Models;

    public class StartUp
    {
        public static void Main()
        {
            using (var db = new BookShopContext())
            {
                //0.Book Shop Database
                //DbInitializer.ResetDatabase(db);

                //1.Age Restriction
                //var result = GetBooksByAgeRestriction(db, "teEN");
                //Console.WriteLine(result);

                //2.Golden Books
                //var result = GetGoldenBooks(db);
                //Console.WriteLine(result);

                //3.Books by Price
                //var result = GetBooksByPrice(db);
                //Console.WriteLine(result);

                //4.Not Released In
                //var result = GetBooksNotReleasedIn(db, 1998);
                //Console.WriteLine(result);

                //5.Book Titles by Category
                //var result = GetBooksByCategory(db, "horror mystery drama");
                //Console.WriteLine(result);

                //6.Released Before Date
                //var result = GetBooksReleasedBefore(db, "12-04-1992");
                //Console.WriteLine(result);

                //7. Author Search 
                //var result = GetAuthorNamesEndingIn(db, "dy");
                //Console.WriteLine(result);

                //8.Book Search
                //var result = GetBookTitlesContaining(db, "sK");
                //Console.WriteLine(result);

                //9.Book Search by Author            
                //var result = GetBooksByAuthor(db, "R");
                //Console.WriteLine(result);

                //10.Count Books
                //var lengthCheck = 12;
                //var result = CountBooks(db, lengthCheck);
                //Console.WriteLine($"There are {result} books with longer title than {lengthCheck} symbols");

                //11.Total Book Copies
                //var result = CountCopiesByAuthor(db);
                //Console.WriteLine(result);

                //12.Profit by Category
                //var result = GetTotalProfitByCategory(db);
                //Console.WriteLine(result);

                //13.Most Recent Books 
                //var result = GetMostRecentBooks(db);
                //Console.WriteLine(result);

                //14.Increase Prices 
                //IncreasePrices(db);

                //15.Remove Books
                //Console.WriteLine(RemoveBooks(db));
            }
        }

        public static string GetBooksByAgeRestriction(BookShopContext context, string command)
        {
            var ageRestriction = Enum.Parse<AgeRestriction>(command, true);

            var books = context.Books
                .Where(a => a.AgeRestriction == ageRestriction)
                .Select(t => t.Title)
                .OrderBy(x => x)
                .ToList();

            var result = string.Join(Environment.NewLine, books);

            return result;
        }

        public static string GetGoldenBooks(BookShopContext context)
        {
            var goldenBooks = context.Books
                .Where(e => e.EditionType == EditionType.Gold)
                .GroupBy(b => new
                {
                    b.BookId,
                    b.Title
                })
                .Select(g => new {
                    GroupId = g.Key.BookId,
                    GroupTitle = g.Key.Title,
                    GroupCopies = g.Sum(s => s.Copies)
                })
                .Where(gc => gc.GroupCopies < 5000)
                .OrderBy(gi => gi.GroupId)
                .ToList();

            var result = string.Join(Environment.NewLine, goldenBooks.Select(v => v.GroupTitle));

            return result;
        }

        public static string GetBooksByPrice(BookShopContext context)
        {
            var books = context.Books
                .Where(p => p.Price > 40)
                .Select(b => new
                {
                    b.Title,
                    b.Price
                })
                .OrderByDescending(p => p.Price)
                .ToList();

            var result = string.Join(Environment.NewLine, books.Select(b => $"{b.Title} - ${b.Price:F2}"));

            return result;
        }

        public static string GetBooksNotReleasedIn(BookShopContext context, int year)
        {
            var books = context.Books
                .Where(d => d.ReleaseDate.Value.Year != year)
                .OrderBy(i => i.BookId)
                .Select(b => b.Title)
                .ToList();

            var result = string.Join(Environment.NewLine, books);

            return result;
        }

        public static string GetBooksByCategory(BookShopContext context, string input)
        {
            var categories = input.ToLower().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            var books = context.Books
                .Where(bc => bc.BookCategories.Any(c => categories.Contains(c.Category.Name.ToLower())))
                .Select(t => t.Title)
                .OrderBy(t => t)
                .ToList();

            var result = string.Join(Environment.NewLine, books);

            return result;
        }

        public static string GetBooksReleasedBefore(BookShopContext context, string date)
        {
            var dt = DateTime.ParseExact(date, "dd-MM-yyyy", CultureInfo.InvariantCulture);

            var books = context.Books
                .Where(b => b.ReleaseDate < dt)
                .OrderByDescending(d => d.ReleaseDate)
                .Select(s => new
                {
                    s.Title,
                    s.EditionType,
                    s.Price
                })
                .ToList();

            var result = string.Join(Environment.NewLine, books.Select(b => $"{b.Title} - {b.EditionType} - ${b.Price:F2}"));

            return result;
        }

        public static string GetAuthorNamesEndingIn(BookShopContext context, string input)
        {
            var autors = context.Authors
                .Where(a => EF.Functions.Like(a.FirstName, "%" + input))
                .Select(au => au)
                .OrderBy(a => a.FirstName)
                .ToList();

            var result = string.Join(Environment.NewLine, autors.Select(a => $"{a.FirstName} {a.LastName}"));

            return result;
        }

        public static string GetBookTitlesContaining(BookShopContext context, string input)
        {
            var books = string.Join(Environment.NewLine, context.Books
                .Where(b => EF.Functions.Like(b.Title, $"%{input}%"))
                .Select(b => b.Title)
                .OrderBy(x => x));

            return books;
        }

        public static string GetBooksByAuthor(BookShopContext context, string input)
        {
            var books = context.Books
                .Where(a => EF.Functions.Like(a.Author.LastName, $"{input}%"))
                .OrderBy(b => b.BookId)
                .Select(x => new
                {
                    x.Title,
                    x.Author.FirstName,
                    x.Author.LastName
                })
                .ToList();

            string result = string.Join(Environment.NewLine, books.Select(x => $"{x.Title} ({x.FirstName} {x.LastName})"));

            return result;
        }

        public static int CountBooks(BookShopContext context, int lengthCheck)
        {
            return context.Books
                .Count(t => t.Title.Length > lengthCheck);
        }

        public static string CountCopiesByAuthor(BookShopContext context)
        {
            var copies = context.Books
                .GroupBy(g => g.Author)
                .Select(b => new
                {
                    Author = b.Key.FirstName + " " + b.Key.LastName,
                    Total = b.Sum(c => c.Copies)
                })
                .OrderByDescending(t => t.Total)
                .ToList();

            var result = string.Join(Environment.NewLine, copies.Select(v => $"{v.Author} - {v.Total}"));

            return result;            
        }

        public static string GetTotalProfitByCategory(BookShopContext context)
        {
            var categories = context.Categories
                .Select(x => new
                {
                    CategoryName = x.Name,
                    TotalProfit = x.CategoryBooks.Sum(e => e.Book.Price * e.Book.Copies)
                })
                .OrderByDescending(t => t.TotalProfit)
                .ThenBy(c => c.CategoryName)
                .ToList();

            string result = string.Join(Environment.NewLine, categories
                .Select(x => $"{x.CategoryName} ${x.TotalProfit:F2}"));

            return result;
        }

        public static string GetMostRecentBooks(BookShopContext context)
        {
            var categories = context.Categories
                .Select(x => new
                {
                    CategoryName = x.Name,
                    Books = x.CategoryBooks.Select(e => new
                    {
                        e.Book.Title,
                        e.Book.ReleaseDate
                    })
                    .OrderByDescending(e => e.ReleaseDate)
                    .Take(3)
                    .ToList()
                })
                .OrderBy(c => c.CategoryName)
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var category in categories)
            {
                sb.AppendLine($"--{category.CategoryName}");

                foreach (var book in category.Books)
                {
                    sb.AppendLine($"{book.Title} ({book.ReleaseDate.Value.Year})");
                }
            }

            return sb.ToString().TrimEnd();
        }

        public static void IncreasePrices(BookShopContext context)
        {
            context.Books
                .Where(b => b.ReleaseDate.Value.Year < 2010)
                .Update(x => new Book() { Price = x.Price + 5 });
        }

        public static int RemoveBooks(BookShopContext context)
        {
            var affectedRows = context.Books
               .Where(b => b.Copies < 4200)
               .Delete();

            return affectedRows;
        }
    }
}