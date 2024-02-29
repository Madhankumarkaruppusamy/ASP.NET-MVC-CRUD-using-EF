using System;
using System.Collections.Generic;
using Models;
using System.Linq;
using System.Threading.Tasks;

namespace Repositories
{
    public interface IBookRepository
    {
    
        public IEnumerable<Book> GetAllBooks();
        public Book  GetByID(int id);
        public void InsertBook(Book detail);
        public void UpdateBook(int id, Book book);
        public void DeleteBook(int bookid);
        public IEnumerable<BookDetail> GetAllBookDetails();

    }
}
