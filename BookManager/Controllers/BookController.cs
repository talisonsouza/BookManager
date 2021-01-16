using BookManager.Database;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookManager.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookController : ControllerBase
    {
        private readonly DataBaseContext _context;

        public BookController(DataBaseContext context)
        {
            _context = context;
        }

        [HttpGet]
        public string Index()
        {

            var books = _context.Book.ToList();
            string ret = "";
            foreach (var item in books)
            {
                ret += $"${item.Name}---";
            }

            return ret;
        }
    }
}
