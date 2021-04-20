using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Domain.Models;
using Api.Domain.Services.Communication;
namespace Api.Domain.Services
{
    public interface ICategoriesService
    {
        public Task<IEnumerable<Categories>>ListAsync();
        public Task<CategoriesResponce>FindByIdAsync(Guid id);
        public Task<CategoriesResponce> SaveAsync(Categories categories);
        public Task<CategoriesResponce> UpdateAsync(Guid id,Categories categories);
        public Task<CategoriesResponce> DeleteAsync(Guid id);
        
    }
}