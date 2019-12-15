using SpiderShark.Domain.Dto;
using SpiderShark.Domain.Dto.UseCaseRequests;
using SpiderShark.Domain.Dto.UseCaseResponses;
using SpiderShark.Domain.Interfaces;
using SpiderShark.Domain.Interfaces.Gateways.Repositories;
using SpiderShark.Domain.Interfaces.Services;
using SpiderShark.Domain.Interfaces.UseCase;
using System.Threading.Tasks;

namespace SpiderShark.Domain.UseCases
{
    public sealed class LoginUseCase : ILoginUseCase
    {
        private readonly IUserRepository _userRepository;
        private readonly IJwtFactory _jwtFactory;

        public LoginUseCase(IUserRepository userRepository, IJwtFactory jwtFactory)
        {
            _userRepository = userRepository;
            _jwtFactory = jwtFactory;
        }

        public async Task<bool> Handle(LoginRequest message, IOutputPort<LoginResponse> outputPort)
        {
            if (!string.IsNullOrEmpty(message.Email) && !string.IsNullOrEmpty(message.Password))
            {
                // confirm we have a user with the given name
                var user = await _userRepository.FindByEmailAndPassword(message.Email, message.Password);

                if (user != null)
                {
                    // generate token
                    outputPort.Handle(new LoginResponse(await _jwtFactory.GenerateEncodedToken(user.GetId(), user.GetUserName()), true));

                    return true;
                }
            }

            outputPort.Handle(new LoginResponse(new[] { Error.Create("login_failure", "Invalid username or password.") }));

            return false;
        }
    }
}
