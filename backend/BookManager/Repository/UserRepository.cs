using BookManager.Entities;
using BookManager.Repository.Context;
using BookManager.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookManager.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly DataBaseContext _context;

        public UserRepository(DataBaseContext context)
        {
            this._context = context;
        }

        public void Delete(int id)
        {
            var user = _context.Users.Where(b => b.Id == id).FirstOrDefault();
            _context.Users.Remove(user);
            _context.SaveChanges();
        }

        public async Task<List<User>> GetAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User> GetAsync(int id)
        {
            return await _context.Users.Where(b => b.Id == id).FirstOrDefaultAsync();
        }

        public void Save(User user)
        {
            _context.Add(user);
            _context.SaveChanges();
        }

        public void SetBookRead(int bookId, int userId, bool bookRead)
        {
            var bookUser = _context.Users.Include(bu => bu.BookUsers).Where(c => c.Id == userId).FirstOrDefault()
                .BookUsers.Where(bu => bu.BookId == bookId).FirstOrDefault();

            bookUser.SetBookRead(bookRead);
            _context.SaveChanges();
        }

        public void SetBorrowedBook(int bookId, int userId)
        {
            var bookUser = _context.Users.Where(c => c.Id == userId).FirstOrDefault()
                    .BookUsers.Where(bu => bu.BookId == bookId).FirstOrDefault();
            bookUser.SetBorrowedBook(true);
            _context.SaveChanges();
        }
    }
}
