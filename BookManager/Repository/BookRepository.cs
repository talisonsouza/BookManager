

using BookManager.Entities;
using BookManager.Repository.Context;
using System.Collections.Generic;
using System.Linq;

namespace BookManager.Repository
{
    public class BookRepository
    {

        private readonly DataBaseContext _context;

        public BookRepository(DataBaseContext context)
        {
            this._context = context;
        }

        public IEnumerable<Book> Get()
        {
            return _context.Book.ToList();            
        }

        public IEnumerable<Book> Get(int id)
        {
            return _context.Book.Where(b => b.Id == id);
        }

        public void Delete(int id)
        {
            var bookToDelete = _context.Book.Where(b => b.Id == id).FirstOrDefault();
            _context.Book.Remove(bookToDelete);
            _context.SaveChanges();
        }

        public void Save(Book book)
        {
            _context.Add(book);
            _context.SaveChanges();
        }

    }
}
