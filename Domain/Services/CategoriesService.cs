using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using Api.Domain.Models;
using Api.Domain.Services;
using Api.Domain.Repositories;
using Api.Domain.Services.Communication;
using System;
using Api.Domain.Services.Logging;

namespace Api.Models.Services
{
    public class CategoriesService : ICategoriesService
    {
        private readonly ICategoriesRepository categoriesRepository;
        private readonly IUnitOfWork unitOfWork;
        private readonly ILoggerManager logger;
        public CategoriesService(ICategoriesRepository categoriesRepository,IUnitOfWork unitOfWork,ILoggerManager logger)
        {
            this.categoriesRepository=categoriesRepository;
            this.unitOfWork=unitOfWork;
            this.logger = logger;
        }

         public async Task<CategoriesResponce> FindByIdAsync(Guid id)
        {
            var categories= await categoriesRepository.FindByIdAsync(id);
            if(categories == null)
                return new CategoriesResponce("Not Found");
                    try{
                        return new CategoriesResponce(categories);
                    }
                 catch(Exception ex){
                    return new CategoriesResponce($"An error accurred when trying to return value of Product:{ex.Message}");
                }
        }

        public async Task<IEnumerable<Categories>> ListAsync()
        {
            return await categoriesRepository.ListAsync(); 
        }

        public async Task<CategoriesResponce>SaveAsync(Categories categories)
        {
            try{
                
                await categoriesRepository.AddAsync(categories);
                await unitOfWork.CompleteAsync();
                return new CategoriesResponce(categories);
            }
            catch(Exception ex){
                return new CategoriesResponce($"An error occurred when saving the Product :{ex.Message}");
            }
        }

        public async Task<CategoriesResponce> UpdateAsync(Guid id, Categories categories)
        {
            var existingProduct=await categoriesRepository.FindByIdAsync(id);
            if(existingProduct==null)
                return new CategoriesResponce("Product Not Found 404");
                existingProduct.Name=categories.Name;
                existingProduct.Icon= categories.Icon;
                existingProduct.TypeId= categories.TypeId;
            try{
                categoriesRepository.Update(existingProduct);
                await unitOfWork.CompleteAsync();
                return new CategoriesResponce(existingProduct);
            }
            catch(Exception ex){
                return new CategoriesResponce($"An error accurred when trying to update product:{ex.Message}");
            }

        }

        public async Task<CategoriesResponce> DeleteAsync(Guid id)
        {
            var existingProduct=await categoriesRepository.FindByIdAsync(id);
            if(existingProduct==null)
                return new CategoriesResponce("Product Not Found 404");
            try{
                categoriesRepository.Remove(existingProduct);
                await unitOfWork.CompleteAsync();
                return new CategoriesResponce(existingProduct);
            }
            catch(Exception ex){
                return new CategoriesResponce($"An error accurred when trying to delete product :{ex.Message}");
            }
        }
    }
}