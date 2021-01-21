using BookManager.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookManager.Repository.Interfaces
{
    public interface IUserRepository
    {
        Task<List<User>> GetAsync();
        Task<User> GetAsync(int id);
        void Delete(int id);
        void Save(User user);
        void SetBookRead(int bookId, int userId, bool bookRead);
        void SetBorrowedBook(int bookId, int userId);
    }
}
