using BookManager.API.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookManager.API.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class EditorController : ControllerBase
    {
        private readonly IEditorRepository _repository;

        public EditorController(IEditorRepository repository)
        {
            _repository = repository;
        }


        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var result = await _repository.GetAsync();
            return Ok(result);
        }
    }
}
