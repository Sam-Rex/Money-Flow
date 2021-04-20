using System.Threading.Tasks;
namespace Api.Domain.Repositories
{
    public interface IUnitOfWork
    {
        Task CompleteAsync();
    }
}