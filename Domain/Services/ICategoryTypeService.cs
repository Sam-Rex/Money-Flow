using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Domain.Models;
using Api.Domain.Services.Communication;
namespace Api.Domain.Services
{
    public interface ICategoryTypeService
    {
        public Task<IEnumerable<CategoriesType>>ListAsync();
        public Task<CategoryTypeResponce>GetByIdAsync(Guid id);
        public Task<CategoryTypeResponce>SaveAsync(CategoriesType categoriesType);
        public Task<CategoryTypeResponce> UpdateAsync(Guid Id,CategoriesType categoriesType);
        public Task<CategoryTypeResponce>DeleteAsync(Guid id);
    }
}