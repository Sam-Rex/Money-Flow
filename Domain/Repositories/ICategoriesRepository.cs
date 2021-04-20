using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Domain.Models;
using System;
namespace Api.Domain.Repositories

{
    public interface ICategoriesRepository
    {
        public Task<IEnumerable<Categories>> ListAsync();

        public Task<Categories> FindByIdAsync(Guid id);

        public Task AddAsync(Categories categories);

        public void Update(Categories categories);

        public void Remove(Categories categories);
        
    }
}