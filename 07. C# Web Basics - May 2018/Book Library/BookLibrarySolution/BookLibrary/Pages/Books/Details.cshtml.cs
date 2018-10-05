namespace BookLibrary.Web.Pages.Books
{
    using BookLibrary.Data.Context;
    using BookLibrary.Data.Models;
    using Microsoft.AspNetCore.Mvc.RazorPages;
    using Microsoft.EntityFrameworkCore;
    using System.Linq;

    public class DetailsModel : PageModel
    {
        private readonly LibraryDbContext db;

        public DetailsModel(LibraryDbContext db)
        {
            this.db = db;
        }

        public Book Book { get; set; }

        public bool EmptyUrl => this.Book.CoverImage == null ? true : false;

        public void OnGet(int id)
            => this.Book = this.db
                    .Books
                    .Include(a => a.Authors)
                    .Where(i => i.Id == id)
                    .Select(b => b)
                    .FirstOrDefault();
        
    }
}