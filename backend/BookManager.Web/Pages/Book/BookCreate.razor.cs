using BookManager.API.Models.Book.Queries;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookManager.API.Entities;
using BookManager.Web.Services;
using BookManager.API.Models;

namespace BookManager.Web.Pages.Book
{
    public partial class BookCreate
    {

        private EditContext editContext;
        [Inject] NavigationManager NavigationManager { get; set; }

        [Parameter]
        public string Id { get; set; }

        BookManager.API.Entities.Book book;
        protected override async Task OnInitializedAsync()
        {
            await Initialize();            
        }

        async Task Initialize()
        {

            if (string.IsNullOrEmpty(Id))            
                book = new API.Entities.Book("","",0,1,1);
            else
                book = await apiService.GetBookByIdAsync(Id);

            editContext = new EditContext(book);
        }

        public async Task handleSubmitClick()
        {
            if (editContext.Validate())
            {
                var result = new CommandResult();

                if (string.IsNullOrEmpty(Id))                 
                    result = await apiService.Insert(book);
                else
                     result = await apiService.Update(book);

                if (result.Success)
                {
                    toastService.ShowToast(result.Message, ToastLevel.Success);
                    NavigationManager.NavigateTo("Book");


                }
                else
                    toastService.ShowToast(result.Message, ToastLevel.Error);

            }            
        }
    }
}
