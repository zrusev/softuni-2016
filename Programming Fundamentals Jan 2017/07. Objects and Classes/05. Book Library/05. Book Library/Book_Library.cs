namespace _05.Book_Library
{
    using System;
    using System.Collections.Generic;
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
                //currentBook.Title = input[0];
                currentBook.Autor = input[1];
                //currentBook.Publisher = input[2];
                //currentBook.ReleaseDate = input[3];
                //currentBook.ISBN = input[4];
                currentBook.Price = double.Parse(input[5]);
                
                //nameOfTheBook.Name = currentBook.Autor;
                nameOfTheBook.Books.Add(currentBook);
                
            }


            var newDict = nameOfTheBook.Books
                .GroupBy(x => x.Autor)
                .ToDictionary(x => x, x => x.Sum(z => z.Price))
                .OrderByDescending(x => x.Value)
                .ThenBy(x => x.Key);

            foreach (var item in newDict)
            {
                Console.WriteLine($"{item.Key.Key} -> {item.Value:F2}");
            }

        }
    }
}
