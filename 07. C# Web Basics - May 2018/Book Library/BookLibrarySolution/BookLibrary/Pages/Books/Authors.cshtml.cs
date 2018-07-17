namespace BookLibrary.Web.Pages.Books
{
    using BookLibrary.Data.Context;
    using BookLibrary.Data.Models;
    using Microsoft.AspNetCore.Mvc.RazorPages;
    using Microsoft.EntityFrameworkCore;
    using System.Linq;

    public class AuthorsModel : PageModel
    {
        private readonly LibraryDbContext db;

        public AuthorsModel(LibraryDbContext db)
        {
            this.db = db;
        }

        public Author Author { get; set; }

        public void OnGet(int id) 
            => this.Author = this.db
                .Authors
                .Include(b => b.Books)
                .Where(a => a.Id == id)
                .Select(au => au)
                .FirstOrDefault();        
    }
}