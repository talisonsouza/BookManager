using BookManager.Entities;
using BookManager.Models;
using BookManager.Models.Book;
using BookManager.Repository.Context;
using BookManager.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookManager.Handles
{
    public class BookHandle
    {
        private readonly IBookRepository _repository;

        public BookHandle(IBookRepository repository)
        {
            this._repository = repository;
        }

        public CommandResult Create(CreateBookModel book)
        {
            
            var _book = new Book(book.Name,book.ISBN,book.NumberPages,book.AuthorId, book.EditorId);

            _repository.Save(_book);            

            return new CommandResult
            {
                Success = true,
                Message = "Cadastro efetuado com sucesso!",
                Data = null
            };
        }
    }
}
