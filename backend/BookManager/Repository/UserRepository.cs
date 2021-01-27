using BookManager.API.Entities;
using BookManager.API.Repository.Context;
using BookManager.API.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookManager.API.Repository
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

        public void SaveReview(int bookId, int userId, string review)
        {
            throw new System.NotImplementedException();
        }

        public void SetBookRead(int bookId, int userId, bool bookRead)
        {
            var bookUser = _context.Users.Include(bu => bu.BookUsers).Where(c => c.Id == userId).FirstOrDefault()
                .BookUsers.Where(bu => bu.BookId == bookId).FirstOrDefault();

            bookUser.SetBookRead(bookRead);
            _context.SaveChanges();
        }

        public void SetBorrowedBook(int bookId, int userId, bool borrowedBook)
        {
            var bookUser = _context.Users.Include(bu => bu.BookUsers).Where(c => c.Id == userId).FirstOrDefault()
                    .BookUsers.Where(bu => bu.BookId == bookId).FirstOrDefault();
            bookUser.SetBorrowedBook(borrowedBook);
            _context.SaveChanges();
        }

        public void SetReviewLike(int bookId, int userId, bool like)
        {
            throw new System.NotImplementedException();
        }
    }
}
