using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Domain.Models;

namespace Api.Domain.Repositories
{
    public interface IMoneyFlowRebository
    {
        public Task<IEnumerable<MoneyFlow>> ListAsync();

        public Task<IEnumerable<MoneyFlow>> getByCategoryAsync(Guid CategoryId);

        public Task<IEnumerable<MoneyFlow>> getByTypeAsync(Guid CategoryTypeId);

        public Task<IEnumerable<MoneyFlow>> getByDateAsync(DateTime date);
        public Task<MoneyFlow> getByIdAsync(Guid id);
        public Task AddAsync(MoneyFlow moneyFlow);
        public void Update(MoneyFlow moneyFlow);
        public void Remove(MoneyFlow moneyFlow);
    }
}
