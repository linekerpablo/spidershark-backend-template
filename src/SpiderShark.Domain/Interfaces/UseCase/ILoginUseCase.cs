using SpiderShark.Domain.Dto.UseCaseRequests;
using SpiderShark.Domain.Dto.UseCaseResponses;

namespace SpiderShark.Domain.Interfaces.UseCase
{
    public interface ILoginUseCase : IUseCaseRequestHandler<LoginRequest, LoginResponse>
    {
    }
}
