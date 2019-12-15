using SpiderShark.Domain.Dto.UseCaseResponses;
using SpiderShark.Domain.Interfaces;

namespace SpiderShark.Domain.Dto.UseCaseRequests
{
    public class LoginRequest : IUseCaseRequest<LoginResponse>
    {
        public string Email { get; }
        public string Password { get; }

        public LoginRequest(string email, string password)
        {
            Email = email;
            Password = password;
        }
    }
}
