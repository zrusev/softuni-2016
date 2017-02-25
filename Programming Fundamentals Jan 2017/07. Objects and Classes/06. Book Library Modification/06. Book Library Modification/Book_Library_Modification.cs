namespace _06.Book_Library_Modification
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;

    class Book_Library
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            Library nameOfTheBook = new Library();
            nameOfTheBook.Books = new List<Book>();

            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine().Split();

                Book currentBook = new Book();
                currentBook.Title = input[0];
                //currentBook.Autor = input[1];
                //currentBook.Publisher = input[2];
                currentBook.ReleaseDate = DateTime.ParseExact(input[3], "dd.MM.yyyy", CultureInfo.InvariantCulture);
                //currentBook.ISBN = input[4];
                //currentBook.Price = double.Parse(input[5]);

                //nameOfTheBook.Name = currentBook.Autor;
                nameOfTheBook.Books.Add(currentBook);

            }
            var givenDate = DateTime.ParseExact(Console.ReadLine(), "dd.MM.yyyy", CultureInfo.InvariantCulture);

            var newList = nameOfTheBook.Books
                .OrderBy(x => x.ReleaseDate)
                .ThenBy(x => x.Title)
                .Where(t => t.ReleaseDate > givenDate);

            foreach (var item in newList)
            {
                    Console.WriteLine($"{item.Title} -> {item.ReleaseDate.ToString("dd.MM.yyyy")}");
            }
        }
    }
}
