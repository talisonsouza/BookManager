using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookManager.API.Entities
{
    public class Book
    {

        //for EF
        public Book(){}

        public Book(string name, string isbn, int numberPages, int authorId, int editorId)
        {            
            Name = name;
            ISBN = isbn;
            NumberPages = numberPages;
            AuthorId = authorId;
            EditorId = editorId;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string ISBN { get; set; }
        public int NumberPages { get; set; }
        public int AuthorId { get; set; }
        public Author Author { get; set; }
        public int EditorId { get; set; }
        public Editor Editor { get; set; }

        public ICollection<BookUser> BookUsers { get; set; }
    }
}
