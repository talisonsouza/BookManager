﻿

using BookManager.Entities;
using BookManager.Repository.Context;
using BookManager.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookManager.Repository
{
    public class BookRepository: IBookRepository
    {

        private readonly DataBaseContext _context;

        public BookRepository(DataBaseContext context)
        {
            this._context = context;
        }

        public List<Book> Get()
        {
            return _context.Book.ToList();
        }

        public async Task<List<Book>> GetAsync()
        {
            return await _context.Book.ToListAsync();         
        }

        public async Task<Book> GetAsync(int id)
        {
            return await _context.Book.Where(b => b.Id == id).FirstOrDefaultAsync();
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
