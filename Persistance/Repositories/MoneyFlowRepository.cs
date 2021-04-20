using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Domain.Models;
using Api.Domain.Repositories;
using Api.Persistance.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Api.Persistance.Repositories
{
    public class MoneyFlowRepository : BaseRepository, IMoneyFlowRebository
    {

        public MoneyFlowRepository(OS_Plus_Money_Flow context) : base(context)
        {

        }

        public async Task AddAsync(MoneyFlow moneyFlow)
        {
            await _context.MoneyFlows.AddAsync(moneyFlow);
        }

        public async Task<MoneyFlow> getByIdAsync(Guid id)
        {
            return await _context.MoneyFlows.Include(p => p.Categories)
                .ThenInclude(p=>p.Type)
                    .FirstOrDefaultAsync(p => p.Id == id);
        }


        public async Task<IEnumerable<MoneyFlow>> getByCategoryAsync(Guid CategoryId)
        {

            return await _context.MoneyFlows
                .Include(p => p.Categories).ThenInclude(p => p.Type)
                    .Where(p => p.CategoryId== CategoryId)
                        .ToListAsync();
        }


        public async Task<IEnumerable<MoneyFlow>> getByTypeAsync(Guid CategoryTypeId)
        {

            return await _context.MoneyFlows
                .Include(p => p.Categories).ThenInclude(p => p.Type)
                    .Where(p => p.Categories.TypeId == CategoryTypeId)
                        .ToListAsync();
        }


        public async Task<IEnumerable<MoneyFlow>> getByDateAsync(DateTime date)
        {

            return await _context.MoneyFlows
                .Include(p => p.Categories).ThenInclude(p => p.Type)
                    .Where(p => p.Date == date)
                        .ToListAsync();
        }


        public async Task<IEnumerable<MoneyFlow>> ListAsync()
        {
            return await _context.MoneyFlows.Include(p => p.Categories)
                .ThenInclude(p => p.Type)
                    .ToListAsync();
        }

        public void Remove(MoneyFlow moneyFlow)
        {
            _context.MoneyFlows.Remove(moneyFlow);
        }

        public void Update(MoneyFlow moneyFlow)
        {
            _context.MoneyFlows.Update(moneyFlow);
        }
    }
        
}
