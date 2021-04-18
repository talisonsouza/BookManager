using BookManager.API.Entities;
using BookManager.API.Models;
using BookManager.API.Models.Book;
using BookManager.API.Repository.Context;
using BookManager.API.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookManager.API.Handles
{
    public class BookHandle
    {
        private readonly IBookRepository _repository;

        public BookHandle(IBookRepository repository)
        {
            this._repository = repository;
        }

        public CommandResult Create(Book book)
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
