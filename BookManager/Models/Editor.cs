using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookManager.Models
{
    public class Editor
    {
        public int EditorId { get; set; }

        public string Name { get; set; }

        public ICollection<Book> Books { get; set; }
    }
}
