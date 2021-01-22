using BookManager.Entities;
using BookManager.Handles;
using BookManager.Models;
using BookManager.Models.Book;
using BookManager.Repository.Interfaces;
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
        private readonly IBookRepository _repository;
        private readonly BookHandle _handler;

        public BookController(IBookRepository repository, BookHandle handle)
        {
            _repository = repository;
            _handler = handle;
        }

        //[HttpGet]
        //public string Index()
        //{            
        //    return "rodrigo";
        //}
   
        [HttpGet]
        public async Task<IActionResult> Index(int Id = 0)
        {
            object book = null;

            if (Id > 0)
                book = await _repository.GetAsync(Id);
            else
                book = await _repository.GetAsync();

            if (book != null) return Ok(book);

            return NotFound();
        }

        [HttpPost]
        public CommandResult Index([FromBody]CreateBookModel model)
        {
            try
            {
                return _handler.Create(model);
            }
            catch (Exception ex)
            {
                return new CommandResult { Success = false, Message = ex.Message };
            } 
        }

        [HttpDelete]
        public CommandResult Delete(int id)
        {
            try
            {
                _repository.Delete(id);
                return new CommandResult
                {
                    Success = true,
                    Message = "Registro deletado com sucesso!"
                };
            }
            catch (Exception ex)
            {
                return new CommandResult { Success = false, Message = ex.Message };
            }
        }

    }
}
