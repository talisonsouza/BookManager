using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookManager.API.Entities
{
    public class BookUser
    {

        public BookUser(int bookId, int userId)
        {
            this.BookId = bookId;
            this.UserId = userId;
        }

        public int BookId { get; private set; }
        public Book Book { get; private set; }

        public int UserId { get; private set; }
        public User User { get; private set; }
        public bool BookRead { get; private set; }

        public bool BorrowedBook { get; private set; }

        public string Review { get; private set; }

        public Int32 ReviewLike { get; private set; }


        public void AddReviewLike()
        {
            this.ReviewLike++;
        }

        public void RemoveReviewLike()
        {
            this.ReviewLike--;
        }

        public void SetReview(string review)
        {
;            this.Review = review;
        }

        public void SetBookRead(bool bookRead)
        {
            this.BookRead = bookRead;
        }

        public void SetBorrowedBook(bool borrowedBook)
        {
            this.BorrowedBook = borrowedBook;
        }
    }
}
