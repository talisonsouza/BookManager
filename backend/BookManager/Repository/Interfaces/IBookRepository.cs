using BookManager.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookManager.Repository.Interfaces
{
    public interface IBookRepository
    {
        List<Book> Get();
        Task<List<Book>> GetAsync();
        Task<Book> GetAsync(int id);
        void Delete(int id);
        void Save(Book book);
    }
}
