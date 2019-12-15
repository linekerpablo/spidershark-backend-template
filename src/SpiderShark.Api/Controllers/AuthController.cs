using Microsoft.AspNetCore.Mvc;
using SpiderShark.Api.Presenters;
using SpiderShark.Domain.Dto.UseCaseRequests;
using SpiderShark.Domain.Interfaces.UseCase;
using SpiderShark.Domain.UseCases;
using System.Threading.Tasks;

namespace SpiderShark.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ILoginUseCase _loginUseCase;
        private readonly LoginPresenter _loginPresenter;

        public AuthController(ILoginUseCase loginUseCase, LoginPresenter loginPresenter)
        {
            _loginUseCase = loginUseCase;
            _loginPresenter = loginPresenter;
        }

        // POST api/auth/login
        [HttpPost("login")]
        public async Task<ActionResult> Login([FromBody] Models.Request.LoginRequest request)
        {
            try
            {
                if (!ModelState.IsValid)
                { // re-render the view when validation failed.
                    return BadRequest(ModelState);
                }

                await _loginUseCase.Handle(new LoginRequest(request.Email, HashPasswordUseCase.Execute(request.Password)), _loginPresenter);

                return _loginPresenter.ContentResult;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }
    }
}