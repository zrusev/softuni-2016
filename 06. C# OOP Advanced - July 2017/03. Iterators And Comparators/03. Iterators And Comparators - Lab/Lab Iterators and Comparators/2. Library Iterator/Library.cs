using System.Collections;
using System.Collections.Generic;

public class Library: IEnumerable<Book>
{
    private List<Book> Books;

    public Library(params Book[] books)
    {
        this.Books = new List<Book>(books);
    }

    public IEnumerator<Book> GetEnumerator()
    {
        return this.Books.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }


    private class LibraryIterator : IEnumerator<Book>
    {
        private int currentIndex;
        private readonly List<Book> books;

        public LibraryIterator(IEnumerable<Book> books)
        {
            this.Reset();
            this.books = new List<Book>(books);
        }

        public Book Current
        {
            get
            {
                return this.books[currentIndex];
            }
        }

        object IEnumerator.Current
        {
            get
            {
                return this.Current;
            }
        }

        public void Dispose()
        {
        }

        public bool MoveNext()
        {
            return ++this.currentIndex < this.books.Count;
        }

        public void Reset()
        {
            this.currentIndex = -1;
        }
    }

}

