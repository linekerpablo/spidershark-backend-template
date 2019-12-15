using SpiderShark.Domain.Dto;
using System.Threading.Tasks;

namespace SpiderShark.Domain.Interfaces.Services
{
    public interface IJwtFactory
    {
        Task<Token> GenerateEncodedToken(long id, string userName);
    }
}
