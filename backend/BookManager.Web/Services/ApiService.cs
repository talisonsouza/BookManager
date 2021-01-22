
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace BookManager.Web.Services
{

    public class Teste
    {
        public int id { get; set; }
        public string name { get;  set; }
        public string isbn { get; set; }
        public int numberPages { get; set; }

        //  "id": 3,
        //"name": "Harry Potter e a pedra filosofal",
        //"isbn": "123455",
        //"numberPages": 250,
        //"authorId": 1,
        //"author": null,
        //"editorId": 1,
        //"editor": null,
        //"bookUsers": null
    }

    public class ApiService
    {
        public HttpClient _httpClient;
        public ApiService(HttpClient client)
        {
            _httpClient = client;
        }

        public async Task<List<Teste>> GetBookAsync()
        {
            var response = await _httpClient.GetAsync("book");
            response.EnsureSuccessStatusCode();
            using var responseContent = await response.Content.ReadAsStreamAsync();
            return await JsonSerializer.DeserializeAsync<List<Teste>>(responseContent);
        }
        
    }
}
