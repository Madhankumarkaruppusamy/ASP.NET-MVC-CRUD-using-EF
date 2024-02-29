using BookDataAccessLayer;
using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly DatabaseContext _contxt;
        public BookRepository(DatabaseContext contxt)
        {
            _contxt = contxt;
        }

        public IEnumerable<Book> GetAllBooks()
        {
            try
            {
                var result = _contxt.Books.Include(x => x.BookDetails).ToList();
                return result;
            }
            catch (Exception )
            {
                throw;
            }
        }

        public IEnumerable<BookDetail> GetAllBookDetails()
        {
            try
            {
                var result = _contxt.BookDetails.Include(x => x.Book).ToList();
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Book GetByID(int id)
        {
            try
            {
                var result = _contxt.Books.Include(x => x.BookDetails).Where(x => x.BookId == id);
                return result.ToList().FirstOrDefault();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void InsertBook(Book book)
        {
            try
            {

                _contxt.Books.Add(book);
                _contxt.SaveChanges();

            }
            catch (Exception )
            {
                throw;
            }
        }

        public void UpdateBook(int id, Book book)
        {
            try
            {
                _contxt.Books.Update(book);
                _contxt.SaveChanges();

            }
            catch (Exception )
            {
                throw;
            }
        }
        public void DeleteBook(int id)
        {
            try
            {
                var book = _contxt.Books.Find(id);
                if (book != null)
                {
                    _contxt.Books.Remove(book);
                    _contxt.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
