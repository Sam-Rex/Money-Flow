using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Domain.Models;
using Api.Domain.Repositories;
using Api.Persistance.Contexts;
using Api.Persistance.Repositories;
using Microsoft.EntityFrameworkCore;
namespace Api.Persistance.Repositories
{
    public class CategoryTypeRepository : BaseRepository, ICategoryTypeRepository
    {
        public CategoryTypeRepository(OS_Plus_Money_Flow context) : base(context)
        {
        }

        public  async Task AddAsync(CategoriesType categoriesType)
        {
            await _context.C_Type.AddAsync(categoriesType);
        }

        public async Task<CategoriesType> FindByIdAsync(Guid id)
        {
            return await _context.C_Type.FindAsync(id);
        }

        public async Task<IEnumerable<CategoriesType>> ListAsync() {

            return await _context.C_Type.ToListAsync();
        }

        public void Remove(CategoriesType categoriesType)
        {
            _context.C_Type.Remove(categoriesType);
        }

        public void Update(CategoriesType categoriesType)
        {
            _context.C_Type.Update(categoriesType);
        }
    }
}