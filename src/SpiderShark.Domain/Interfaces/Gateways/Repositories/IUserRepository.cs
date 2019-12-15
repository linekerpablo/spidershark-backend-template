using SpiderShark.Domain.Dto.GatewayResponses.Repositories;
using SpiderShark.Domain.Entities;
using System.Threading.Tasks;

namespace SpiderShark.Domain.Interfaces.Gateways.Repositories
{
    public interface IUserRepository
    {
        Task<CreateUserResponse> Create(User user, string password);
        Task<User> FindByEmailAndPassword(string email, string password);
    }
}
