namespace BookLibrary.Data.Models
{
    public class Trel_BookBorrower
    {
        public int BookId { get; set; }
        public int BorrowerId { get; set; }

        public Book BooksNavigation { get; set; }

        public Borrower BorrowersNavigation { get; set; }
    }
}
