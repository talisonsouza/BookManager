using BookManager.API.Models.Book.Queries;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookManager.API.Entities;

namespace BookManager.Web.Pages.Book
{
    public partial class BookCreate
    {

        private EditContext editContext;


        [Parameter]
        public string Id { get; set; }

        BookManager.API.Entities.Book book;
        protected override async Task OnInitializedAsync()
        {

            book = await apiService.GetBookByIdAsync(Id);
            editContext = new EditContext(book);
        }

        public async void handleSubmitClick()
        {
            if (editContext.Validate())
            {
                await apiService.Update(book);
            }
            //await apiService.GetBookByIdAsync(Id);
        }
    }
}
