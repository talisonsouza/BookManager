using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookManager.Models.User
{
    public class UpdateBookRead
    {

        public bool BookRead { get; set; }

        public int BookId { get; set; }

        public int UserId { get; set; }
    }
}
