using System.Collections.Generic;

namespace SpiderShark.Domain.Dto.GatewayResponses.Repositories
{
    public sealed class CreateUserResponse : BaseGatewayResponse
    {
        public long Id { get; }
        public CreateUserResponse(long id, bool success = false, IEnumerable<Error> errors = null) : base(success, errors)
        {
            Id = id;
        }
    }
}
