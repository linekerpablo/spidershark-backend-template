using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SpiderShark.Domain.Dto;
using SpiderShark.Domain.Dto.GatewayResponses.Repositories;
using SpiderShark.Domain.Entities;
using SpiderShark.Domain.Interfaces.Gateways.Repositories;
using SpiderShark.Gateway.Data.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpiderShark.Gateway.Data.EntityFramework.Repositories
{
    internal sealed class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly IMapper _mapper;

        public UserRepository(ApplicationDbContext applicationDbContext,
            IMapper mapper)
        {
            _applicationDbContext = applicationDbContext;
            _mapper = mapper;
        }

        public async Task<CreateUserResponse> Create(User user, string password)
        {
            var gatewayUser = _mapper.Map<GatewayUser>(user);

            var result = await _applicationDbContext.User.AddAsync(gatewayUser);

            await _applicationDbContext.SaveChangesAsync();

            var success = result != null && result.Entity.Id > 0 ? true : false;

            List<Error> error = new List<Error>()
                {
                    Error.Create("createuser_error", "Error with created user")
                };

            return new CreateUserResponse(gatewayUser.Id, success, success ? null : error.AsEnumerable());
        }

        public async Task<User> FindByEmailAndPassword(string email, string password)
        {
            var users = await _applicationDbContext.User.ToListAsync();

            var user = users.Where(tmp => tmp.Email.Equals(email) && tmp.PasswordHash.Equals(password)).FirstOrDefault();

            return user != null ? _mapper.Map<User>(user) : null;
        }
    }
}
