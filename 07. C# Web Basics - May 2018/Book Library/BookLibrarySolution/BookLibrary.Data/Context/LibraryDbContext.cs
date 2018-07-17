namespace BookLibrary.Data.Context
{
    using BookLibrary.Data.Models;
    using Microsoft.EntityFrameworkCore;
    public class LibraryDbContext : DbContext
    {
        public LibraryDbContext(DbContextOptions<LibraryDbContext> options)
            : base(options)
        {
        }
        public DbSet<Book> Books { get; set; }

        public DbSet<Author> Authors { get; set; }

        public DbSet<Borrower> Borrowers { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Trel_BookBorrower>()
                .HasKey(k => new { k.BookId, k.BorrowerId });

            builder.Entity<Trel_BookBorrower>()
                .HasOne(a => a.BooksNavigation)
                .WithMany(b => b.Borrower)
                .HasForeignKey(k => k.BookId);

            builder.Entity<Trel_BookBorrower>()
                .HasOne(b => b.BorrowersNavigation)
                .WithMany(a => a.Books)
                .HasForeignKey(k => k.BorrowerId);

            base.OnModelCreating(builder);
        }
    }
}
