using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineBookStoreProject.Models
{
    public class BookRepository : IBookRepository
    {
        private readonly BookDbContext _bookDbContext;

        public BookRepository(BookDbContext bookDbContext)
        {
            _bookDbContext = bookDbContext;
        }

        public IEnumerable<Book> GetAllBooks
        {
            get
            {
                return _bookDbContext.Books.Include(c => c.Category);
            }
        }
        public IEnumerable<Book> BooksOnSale
        {
            get
            {
                return _bookDbContext.Books.Include(c => c.Category).Where(p => p.Onsale);
            }
        }
        public Book GetBookById(int bookId)
        {
            return _bookDbContext.Books.FirstOrDefault(b => b.BookId == bookId);
        }
    }
}
