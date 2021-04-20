using System.Threading.Tasks;
using Api.Resources;
namespace Api.Domain.Services.Account
{
    public interface IAccountServices
    {
        public Task<bool> ValidateUser(LoginResources loginResources);
        public Task<string> CreateToken();
    }
}
