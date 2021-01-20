using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookManager.Entities
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

        public int Id { get; private set; }
        public string Name { get; private set; }
        public string ISBN { get; private set; }
        public int NumberPages { get; private set; }
        public int AuthorId { get; private set; }
        public Author Author { get; private set; }
        public int EditorId { get; private set; }
        public Editor Editor { get; private set; }

        public ICollection<BookUser> BookUsers { get; set; }
    }
}
