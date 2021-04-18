using BookManager.API.Entities;
using BookManager.API.Repository.Context;
using BookManager.API.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookManager.API.Repository
{
    public class EditorRepository : IEditorRepository
    {
        private readonly DataBaseContext _context;

        public EditorRepository(DataBaseContext context)
        {
            this._context = context;
        }


        public void Delete(int id)
        {
            var editorToDelete = _context.Editor.Where(b => b.Id == id).FirstOrDefault();
            _context.Editor.Remove(editorToDelete);
            _context.SaveChanges();
            
        }

        public List<Editor> Get()
        {
            return _context.Editor.ToList();
            
        }

        public async Task<List<Editor>> GetAsync()
        {
            return await _context.Editor.ToListAsync();            
        }

        public async Task<Editor> GetAsync(int id)
        {

            return await _context.Editor.Where(b => b.Id == id).FirstOrDefaultAsync();            
        }

        public void Save(Editor editor)
        {
            _context.Add(editor);
            _context.SaveChanges();            
        }

        public async Task Update(Editor editor)
        {
            _context.Entry(editor).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            
        }
    }
}
