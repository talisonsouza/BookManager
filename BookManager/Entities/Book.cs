using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookManager.Entities
{
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ISBN { get; set; }
        public int numberPages { get; set; }
        public int AuthorId { get; set; }
        public Author Author { get; set; }
        public int EditorId { get; set; }
        public Editor Editor { get; set; }
    }
}
