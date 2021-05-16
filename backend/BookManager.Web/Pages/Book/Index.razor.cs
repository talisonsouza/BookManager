using BookManager.API.Models.Book.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookManager.Web.Pages.Book
{
    public partial class Index
    {

        public void edit(int id)
        {
            UriHelper.NavigateTo("bookCreate/" + id);
        }


        List<GetBookResult> books;
        protected override async Task OnInitializedAsync()
        {

            books = await apiService.GetBookAsync();
        }


        public async Task Delete(int id)
        {
            var result = await apiService.Delete(id);
            if (result.Success)
            {
                toastService.ShowToast(result.Message, Services.ToastLevel.Success);
                await OnInitializedAsync();
            }
            else
            {
                toastService.ShowToast("Erro ao deletar registro", Services.ToastLevel.Error);
            }
        }
    }
}
