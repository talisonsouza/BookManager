using BookManager.Repository.Context;
using BookManager.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        public async Task<IActionResult>  Index()
        {
            var books = await _context.Book.ToListAsync();

            if(books.Count > 0)            
                return Ok(books);            

            return NotFound();
        }

        [HttpPost]
        public string Index(Book data)
        {
            try
            {
                _context.Book.Add(data);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw;
            }

            return "ok";                       
        }

    }
}
