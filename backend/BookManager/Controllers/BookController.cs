using BookManager.API.Entities;
using BookManager.API.Handles;
using BookManager.API.Models;
using BookManager.API.Models.Book;
using BookManager.API.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookManager.API.Controllers
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


        [HttpGet("GetObj")]
        public IActionResult GetObject()
        {
            object book = new 
            { 
                Codigo=1,
                Descricao=""
            };          

            return Ok(book);            
        }


        [HttpPost("insert")]
        public CommandResult Index([FromBody] Book book)
        {
            try
            {
                return _handler.Create(book);
            }
            catch (Exception ex)
            {
                return new CommandResult { Success = false, Message = ex.Message };
            } 
        }

        [HttpPut("atualizar")]
        public CommandResult Update([FromBody] Book book)
        {
            try
            {
                _repository.Update(book);
                return new CommandResult { Success = true, Message = "Dados atualizados com sucesso!" };
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
