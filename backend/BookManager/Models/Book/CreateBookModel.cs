using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookManager.API.Models.Book
{
    public class CreateBookModel
    {
        public string Name { get; set; }        
        public string ISBN { get; set; }
        public int NumberPages { get;  set; }
        public int AuthorId { get;  set; }        
        public int EditorId { get;  set; }
        
    }
}
