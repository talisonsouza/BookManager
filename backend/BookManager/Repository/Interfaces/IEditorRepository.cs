using BookManager.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookManager.API.Repository.Interfaces
{
    public interface IEditorRepository
    {
        List<Editor> Get();
        Task<List<Editor>> GetAsync();
        Task<Editor> GetAsync(int id);
        Task Update(Editor editor);
        void Delete(int id);
        void Save(Editor editor);
    }
}
