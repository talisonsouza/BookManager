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

        public async void Delete(int id)
        {
            var user = _context.Users.AsNoTracking().Where(b => b.Id == id).FirstOrDefault();
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
        }

        public async Task<List<User>> GetAsync()
        {
            return await _context.Users.AsNoTracking().ToListAsync();
        }

        public async Task<User> GetAsync(int id)
        {
            return await _context.Users.AsNoTracking().Where(b => b.Id == id).FirstOrDefaultAsync();
        }

        public async void Save(User user)
        {
            _context.Add(user);
            await _context.SaveChangesAsync();
        }

        public async void SaveReview(int bookId, int userId, string review)
        {
            var bookUser = _context.Users.Include(bu => bu.BookUsers).Where(c => c.Id == userId).FirstOrDefault()
                                .BookUsers.Where(bu => bu.BookId == bookId).FirstOrDefault();
            
            if(bookUser != null)
            {
                bookUser.SetReview(review);
                await _context.SaveChangesAsync();
            }
        }

        public async void SetBookRead(int bookId, int userId, bool bookRead)
        {
            var bookUser = _context.Users.Include(bu => bu.BookUsers).Where(c => c.Id == userId).FirstOrDefault()
                .BookUsers.Where(bu => bu.BookId == bookId).FirstOrDefault();

            if(bookUser != null)
            {
                bookUser.SetBookRead(bookRead);
                await _context.SaveChangesAsync();
            }
        }

        public async void SetBorrowedBook(int bookId, int userId, bool borrowedBook)
        {
            var bookUser = _context.Users.Include(bu => bu.BookUsers).Where(c => c.Id == userId).FirstOrDefault()
                    .BookUsers.Where(bu => bu.BookId == bookId).FirstOrDefault();
            bookUser.SetBorrowedBook(borrowedBook);
            await _context.SaveChangesAsync();
        }

        public void SetReviewLike(int bookId, int userId, bool like)
        {
            throw new System.NotImplementedException();
        }
    }
}
