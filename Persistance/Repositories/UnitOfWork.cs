using System.Threading.Tasks;
using Api.Domain.Repositories;
using Api.Persistance.Contexts;
namespace Api.Persistance.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly OS_Plus_Money_Flow _context;
        public UnitOfWork(OS_Plus_Money_Flow context)
        {
            _context=context;
        }

        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}