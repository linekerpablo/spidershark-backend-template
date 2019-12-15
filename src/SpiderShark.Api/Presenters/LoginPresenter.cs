using Newtonsoft.Json;
using SpiderShark.Domain.Dto.UseCaseResponses;
using SpiderShark.Domain.Interfaces;
using System.Net;

namespace SpiderShark.Api.Presenters
{
    public sealed class LoginPresenter : IOutputPort<LoginResponse>
    {
        public JsonContentResult ContentResult { get; }

        public LoginPresenter()
        {
            ContentResult = new JsonContentResult();
        }

        public void Handle(LoginResponse response)
        {
            ContentResult.StatusCode = (int)(response.Success ? HttpStatusCode.OK : HttpStatusCode.Unauthorized);
            ContentResult.Content = response.Success ? JsonConvert.SerializeObject(response.Token) : JsonConvert.SerializeObject(response.Errors);
        }
    }
}
