using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Domain.Models;
using Api.Domain.Repositories;
using Api.Domain.Services.Communication;
using Api.Domain.Services.Logging;

namespace Api.Domain.Services
{
    public class MoneyFlowService:IMoneyFlowService
    {
        private readonly IMoneyFlowRebository moneyFlowRebository;
        private readonly IUnitOfWork unitOfWork;
        private readonly ILoggerManager logger;
        public MoneyFlowService(IMoneyFlowRebository moneyFlowRebository, IUnitOfWork unitOfWork, ILoggerManager logger)
        {
            this.moneyFlowRebository = moneyFlowRebository;
            this.unitOfWork = unitOfWork;
            this.logger = logger;
        }


        public async Task<MoneyFlowResponce> DeleteAsync(Guid id)
        {
            var existingFlow = await moneyFlowRebository.getByIdAsync(id);
            if (existingFlow == null)

                return new MoneyFlowResponce("Category  money flow please contact system administrator not found");
            try
            {
                moneyFlowRebository.Remove(existingFlow);
                await unitOfWork.CompleteAsync();
                return new MoneyFlowResponce(existingFlow);
            }
            catch (Exception ex)
            {

                logger.LogError($"An error accurred when updating money flow please contact system administrator:{ ex.Message}");
                return new MoneyFlowResponce($"An error accurred when trying to erase the value of Money Flow ");
            }
        }

        public async Task<MoneyFlowResponce> FindByIdAsync(Guid id)
        {
            var flows = await moneyFlowRebository.getByIdAsync(id);
            if (flows == null)
                return new MoneyFlowResponce("Not Found");
            try
            {
                return new MoneyFlowResponce(flows);
            }
            catch (Exception ex)
            {
                logger.LogError($"An error accurred when updating money flow please contact system administrator:{ ex.Message}");
                return new MoneyFlowResponce($"An error accurred when trying to retrive value of Money Flow ");
            }
        }

        public async Task<IEnumerable<MoneyFlow>> FindByCategoryAsync(Guid CategoryId)
        {
            return await moneyFlowRebository.getByCategoryAsync(CategoryId); ;
        }


        public async Task<IEnumerable<MoneyFlow>> FindByCategoryTypeAsync(Guid CategoryTyped)
        {
            return await moneyFlowRebository.getByTypeAsync(CategoryTyped); ;
        }




        public async Task<IEnumerable<MoneyFlow>> FindByDateAsync(DateTime date)
        {
            return await moneyFlowRebository.getByDateAsync(date);
        }

        public async Task<IEnumerable<MoneyFlow>> ListAsync()
        {
            return await moneyFlowRebository.ListAsync();
        }

        public async Task<MoneyFlowResponce> SaveAsync(MoneyFlow moneyFlow)
        {
            try
            {
                await moneyFlowRebository.AddAsync(moneyFlow);
                await unitOfWork.CompleteAsync();

                return new MoneyFlowResponce(moneyFlow);
            }
            catch (Exception ex)
            {
                logger.LogError($"An error accurred when saving new money flow please contact system administrator:{ ex.Message}");
                return new MoneyFlowResponce($"An error occurred when saving the money flow please contact system administrator:{ex.Message}");
            }
        }

        public async Task<MoneyFlowResponce> UpdateAsync(Guid id, MoneyFlow moneyFlow)
        {
            var existingFlow = await moneyFlowRebository.getByIdAsync(id);
            if (existingFlow == null)
                return new MoneyFlowResponce("Money Flow not Found 404");
            existingFlow.amount = moneyFlow.amount;
            existingFlow.Date= moneyFlow.Date;
            existingFlow.Description = moneyFlow.Description;
            existingFlow.CategoryId= moneyFlow.CategoryId;
            
            try
            {
                moneyFlowRebository.Update(existingFlow);
                await unitOfWork.CompleteAsync();
                return new MoneyFlowResponce(existingFlow);
            }
            catch (Exception ex)
            {
                logger.LogError($"An error accurred when updating money flow please contact system administrator:{ ex.Message}");
                return new MoneyFlowResponce($"An error accurred when updating the money flow please contact system administrator");
            }
        }


    }
}
