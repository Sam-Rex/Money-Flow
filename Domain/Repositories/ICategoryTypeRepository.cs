using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Domain.Models;
using System;
namespace Api.Domain.Repositories

{
    public interface ICategoryTypeRepository
    {
        public Task<IEnumerable<CategoriesType>> ListAsync();
        public Task AddAsync(CategoriesType categoriesType);
        public Task<CategoriesType> FindByIdAsync(Guid id);

        public void Update(CategoriesType categoriesType);
        public void Remove(CategoriesType categoriesType);
    }
}