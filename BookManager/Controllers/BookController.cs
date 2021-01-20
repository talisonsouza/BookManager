using BookManager.Entities;
using BookManager.Handles;
using BookManager.Models;
using BookManager.Models.Book;
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
        private readonly BookHandle _handler;

        public BookController(IBookRepository repository, BookHandle handle)
        {
            _repository = repository;
            _handler = handle;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var books = await _repository.GetAsync();

            if(books.Count() > 0)            
                return Ok(books);            

            return NotFound();
        }

        [HttpPost]
        public async Task<CommandResult> Index([FromBody]CreateBookModel model)
        {
            try
            {
                return await _handler.Create(model);
            }
            catch (Exception ex)
            {
                return new CommandResult { Success = false, Message = ex.Message };
            } 
        }

    }
}
