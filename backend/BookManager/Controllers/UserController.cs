using BookManager.Models;
using BookManager.Models.User;
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
    public class UserController : ControllerBase
    {

        private readonly IUserRepository _repository;

        public UserController(IUserRepository repository)
        {
            _repository = repository;
        }

        [HttpPost]
        public CommandResult SetSetBookRead([FromBody] UpdateBookRead data)
        {
            try
            {
                _repository.SetBookRead(data.BookId, data.UserId, data.BookRead);
                return new CommandResult { Success = true, Message = "Sucesso" };
            }
            catch (Exception ex)
            {
                return new CommandResult { Success = false, Message = ex.Message };
            }

        }
    }
}
