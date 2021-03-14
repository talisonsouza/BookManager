using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookManager.API.Models.Book.Queries
{
    public class GetBookResult
    {
        public int id { get; set; }

        [Required]
        public string name { get; set; }

        [Required]
        public string isbn { get; set; }

        [Required]
        public int numberPages { get; set; }

    }
}
