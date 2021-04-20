using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Domain.Models;
using Api.Domain.Services.Communication;

namespace Api.Domain.Services
{
    public interface IMoneyFlowService
    {
        public Task<IEnumerable<MoneyFlow>> ListAsync();
        public Task<MoneyFlowResponce> FindByIdAsync(Guid id);
        public Task<IEnumerable<MoneyFlow>> FindByCategoryAsync(Guid CategoryId);
        public Task<IEnumerable<MoneyFlow>> FindByCategoryTypeAsync(Guid CategoryTyped);
        public Task<IEnumerable<MoneyFlow>> FindByDateAsync(DateTime date);

        public Task<MoneyFlowResponce> SaveAsync(MoneyFlow moneyFlow);
        public Task<MoneyFlowResponce> UpdateAsync(Guid id, MoneyFlow moneyFlow);
        public Task<MoneyFlowResponce> DeleteAsync(Guid id);

    }
}
