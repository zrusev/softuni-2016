using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookLibrary.Data.Context;
using BookLibrary.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace BookLibrary.Pages
{
    public class IndexModel : PageModel
    {
        private readonly LibraryDbContext db;

        public IndexModel(LibraryDbContext db)
        {
            this.db = db;
        }

        [TempData]
        public string Message { get; set; }

        public bool ShowMessage => !string.IsNullOrEmpty(this.Message);

        public ICollection<Book> Library { get; set; }

        public void OnGet()
        {
            this.Library = this.db
                .Books
                .Include(a => a.Authors)
                .ToList();
        }
    }
}
