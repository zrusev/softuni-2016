namespace BookLibrary.Web.Pages
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using BookLibrary.Data.Context;
    using BookLibrary.Data.Models;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.RazorPages;
    using Microsoft.EntityFrameworkCore;

    public class SearchModel : PageModel
    {
        private readonly LibraryDbContext db;

        public SearchModel(LibraryDbContext db)
        {
            this.db = db;
        }

        public ICollection<Book> Library { get; set; } = new List<Book>();

        public string SearchWord { get; set; }

        public void OnPost(string searchTerm)
        {
            this.SearchWord = searchTerm;

            this.Library = this.db
                .Books
                .Select(b => new Book
                {
                    Id = b.Id,
                    Title = b.Title,
                    Authors = new Author
                    {
                        Id = b.Authors.Id,
                        Name = b.Authors.Name
                    }
                })
                .Where(trm => trm.Title.Contains(searchTerm) || trm.Authors.Name.Contains(searchTerm))
                .ToList();
        }
    }
}