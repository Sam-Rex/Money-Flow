using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Domain.Models;
using Api.Domain.Services;
using Api.Domain.Repositories;
using Api.Domain.Services.Communication;
using System;
using Api.Domain.Services.Logging;

namespace Api.Models.Services
{
    public class CategoryTypeService : ICategoryTypeService
    {
        private readonly ICategoryTypeRepository categoryTypeRepository;
        private readonly IUnitOfWork unitOfWork;
        private readonly ILoggerManager logger;
        public CategoryTypeService(ICategoryTypeRepository categoryRepository,IUnitOfWork unitOfWork,ILoggerManager logger)
        {
            this.categoryTypeRepository=categoryRepository;
            this.unitOfWork=unitOfWork;
            this.logger = logger;
        }


        public async Task<CategoryTypeResponce> DeleteAsync(Guid id)
        {
            var existingType= await categoryTypeRepository.FindByIdAsync(id);
                if(existingType==null)
                    
                    return new CategoryTypeResponce("Category  Type not found");
                try{
                    categoryTypeRepository.Remove(existingType);
                    await unitOfWork.CompleteAsync();
                    return new CategoryTypeResponce(existingType);
                }
                catch(Exception ex){

                logger.LogError($"An error accurred when updating Type:{ ex.Message}");
                return new CategoryTypeResponce($"An error accurred when trying to erase the value of type");
                }
        }

        public async Task<CategoryTypeResponce> GetByIdAsync(Guid id)
        {
            var categories= await categoryTypeRepository.FindByIdAsync(id);
            if(categories==null)
                return new CategoryTypeResponce("Not Found");
                    try{
                        return new CategoryTypeResponce(categories);
                    }
                 catch(Exception ex){
                logger.LogError($"An error accurred when updating Type:{ ex.Message}");
                return new CategoryTypeResponce($"An error accurred when trying to retrive value of type");
                }
        }

        public async Task<IEnumerable<CategoriesType>> ListAsync()
        {
            return await categoryTypeRepository.ListAsync();
        }

        public async Task<CategoryTypeResponce> SaveAsync(CategoriesType categoriesType)
        {
            try{
                await categoryTypeRepository.AddAsync(categoriesType);
                await unitOfWork.CompleteAsync();

                return new CategoryTypeResponce(categoriesType);
            }
            catch(Exception ex){
                logger.LogError($"An error accurred when saving new Type:{ ex.Message}");
                return new CategoryTypeResponce($"An error occurred when saving the category :{ex.Message}");
            }
        }

        public async Task<CategoryTypeResponce> UpdateAsync(Guid id, CategoriesType categoriesType)
        {
            var existingType=await categoryTypeRepository.FindByIdAsync(id);
            if(existingType==null)
                return new CategoryTypeResponce("Category Not Found 404");
                existingType.Name= categoriesType.Name;
                existingType.Description= categoriesType.Description;
            try
            {
                    categoryTypeRepository.Update(existingType);
                    await unitOfWork.CompleteAsync();
                    return new CategoryTypeResponce(existingType);
                }
                catch(Exception ex){
                    logger.LogError($"An error accurred when updating Type:{ ex.Message}");
                    return new CategoryTypeResponce($"An error accurred when updating the Type");
                }
        }

        
    }
}