using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineBookStoreProject.Models
{
    public interface IBookRepository
    {
        IEnumerable<Book> GetAllBooks { get; }
        IEnumerable<Book> BooksOnSale { get; }
        Book GetBookById(int bookId);
    }
}
