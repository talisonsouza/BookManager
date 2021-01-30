
using BookManager.API.Models.Book.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace BookManager.Web.Services.Book
{

    //public class Teste
    //{
    //    public int id { get; set; }
    //    public string name { get;  set; }
    //    public string isbn { get; set; }
    //    public int numberPages { get; set; }

    //    // "id": 3,
    //    //"name": "Harry Potter e a pedra filosofal",
    //    //"isbn": "123455",
    //    //"numberPages": 250,
    //    //"authorId": 1,
    //    //"author": null,
    //    //"editorId": 1,
    //    //"editor": null,
    //    //"bookUsers": null
    //}

    public class ApiService
    {
        public HttpClient _httpClient;
        public ApiService(HttpClient client)
        {
            _httpClient = client;
        }

        public async Task<List<GetBookResult>> GetBookAsync()
        {
            var response = await _httpClient.GetAsync("book");
            response.EnsureSuccessStatusCode();
            using var responseContent = await response.Content.ReadAsStreamAsync();
            return await JsonSerializer.DeserializeAsync<List<GetBookResult>>(responseContent);
        }

        public async Task<GetBookResult> GetBookByIdAsync(string id)
        {
            var response = await _httpClient.GetAsync($"book?id={id}");
            response.EnsureSuccessStatusCode();
            using var responseContent = await response.Content.ReadAsStreamAsync();
            return await JsonSerializer.DeserializeAsync<GetBookResult>(responseContent);
        }

    }
}
