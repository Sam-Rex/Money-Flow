using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Api.Domain.Models;
using Api.Domain.Repositories;
using Api.Persistance.Contexts;
using System;

namespace Api.Persistance.Repositories
{
    public class CategoriesRepository:BaseRepository,ICategoriesRepository
    {
        public CategoriesRepository(OS_Plus_Money_Flow context):base(context)
        {
            
        }

        public async Task<Categories> FindByIdAsync(Guid id)
        {
            return await _context.Categories.Include(p => p.Type).FirstOrDefaultAsync(p=>p.Id==id);
        }

        public async Task<IEnumerable<Categories>>ListAsync(){
            return await _context.Categories.Include(p => p.Type).ToListAsync();
        }

        public async Task AddAsync(Categories categories){
            
             await _context.Categories.AddAsync(categories);

        }

        public void Update(Categories categories)
        {
            _context.Categories.Update(categories);
        }

        public void Remove(Categories categories)
        {
            _context.Categories.Remove(categories);
        }
    }
}