using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookManager.API.Models.Book.Queries
{
    public class GetBookResult
    {
        public int id { get; set; }
        public string name { get; set; }
        public string isbn { get; set; }
        public int numberPages { get; set; }

    }
}
