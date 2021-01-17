using BookManager.Entities;
using BookManager.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace BookManager.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookController : ControllerBase
    {
        private readonly IBookRepository _repository;

        public BookController(IBookRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult>  Index()
        {
            var books = await _repository.GetAsync();

            if(books.Count() > 0)            
                return Ok(books);            

            return NotFound();
        }

        [HttpPost]
        public string Index(Book book)
        {
            try
            {
                _repository.Save(book);                
            }
            catch (Exception ex)
            {
                throw;
            }

            return "ok";                       
        }

    }
}
