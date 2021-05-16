
using BookManager.API.Entities;
using BookManager.API.Models;
using BookManager.API.Models.Book.Queries;
using BookManager.Web.Models;
using Microsoft.AspNetCore.Components;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;


namespace BookManager.Web.Services.Books
{

    public class Endereco
    {

        public string cep { get; set; }
        public string logradouro { get; set; }
        public string complemento { get; set; }
        public string bairro { get; set; }

        public string localidade { get; set; }
        public string uf { get; set; }
        public string ibge { get; set; }
        public string ddd { get; set; }
 
    }    

    public class ApiService
    {   

        public HttpClient _httpClient;
        public ApiService(HttpClient client)
        {
            _httpClient = client;
        }        

        public async Task<List<GetBookResult>> GetBookAsync()
        {
           return await _httpClient.GetFromJsonAsync<List<GetBookResult>>("book");
        }

        public async Task<Book> GetBookByIdAsync(string id)
        {
           return await _httpClient.GetFromJsonAsync<Book>($"book?id={id}");
        }

        public async Task<CommandResult> Update(Book book)
        {
            try
            {
                var result = await _httpClient.PutAsJsonAsync($"book/atualizar/", book);
                result.EnsureSuccessStatusCode();                
                return new CommandResult { Message = "Dados atualizados com sucess!", Success = true };
            }
            catch (Exception ex)
            {
                return new CommandResult { Message = ex.Message, Success = false };                
            }
            
        }

        public async Task<CommandResult> Insert(Book book)
        {
            try
            {
                var result = await _httpClient.PostAsJsonAsync($"book/insert/", book);                
                result.EnsureSuccessStatusCode();
                return new CommandResult { Message = "Dados cadastrados com sucesso!", Success = true };
            }
            catch (Exception ex)
            {
                return new CommandResult { Message = ex.Message, Success = false };
            }

        }


        public async Task<CommandResult> Delete(int id)
        {
            try
            {
                var result = await _httpClient.DeleteAsync($"book/delete?id={id}");
                result.EnsureSuccessStatusCode();
                return new CommandResult { Message = "Dados cadastrados com sucesso!", Success = true };
            }
            catch (Exception ex)
            {
                return new CommandResult { Message = ex.Message, Success = false };
            }

        }

    }
}
