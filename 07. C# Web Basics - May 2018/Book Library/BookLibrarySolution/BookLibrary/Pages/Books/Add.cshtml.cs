namespace BookLibrary.Web.Pages.Books
{
    using BookLibrary.Data.Context;
    using BookLibrary.Data.Models;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.RazorPages;
    using System;
    using System.Linq;
    public class AddModel : PageModel
    {
        private readonly LibraryDbContext db;

        public AddModel(LibraryDbContext db)
        {
            this.db = db;
        }

        [BindProperty]
        public Book Book { get; set; }

        [TempData]
        public string Message { get; set; }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                Author author;
                author = this.db
                    .Authors
                    .Where(au => au.Name == this.Book.Authors.Name)
                    .Select(a => a)
                    .FirstOrDefault();

                if (author == null)
                {
                    author = new Author
                    {
                        Name = this.Book.Authors.Name
                    };

                    this.db.Authors.Add(author);
                    this.db.SaveChanges();
                }

                this.Book.Authors.Id = author.Id;

                this.db.Add(this.Book);
                this.db.SaveChanges();
            }
            catch (Exception e)
            {
                Message = e.Message;
                return Page();
            }

            return RedirectToPage("/Index");
        }
    }
}