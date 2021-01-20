using BookManager.Entities;
using BookManager.Models;
using BookManager.Models.Book;
using BookManager.Repository.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookManager.Handles
{
    public class BookHandle
    {
        private readonly DataBaseContext _context;

        public BookHandle(DataBaseContext context)
        {
            this._context = context;
        }

        public async Task<CommandResult> Create(CreateBookModel book)
        {
            var _book = new Book(book.Name,book.ISBN,book.NumberPages,book.AuthorId, book.EditorId);

             _context.Book.Add(_book);
            await _context.SaveChangesAsync();

            return new CommandResult
            {
                Success = true,
                Message = "Cadastro efetuado com sucesso!",
                Data = null
            };
        }

    }
}
