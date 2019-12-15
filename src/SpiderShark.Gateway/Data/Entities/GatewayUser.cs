using SpiderShark.Gateway.Data.EntityFramework.Entities;

namespace SpiderShark.Gateway.Data.Entities
{
    public class GatewayUser : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string PasswordHash { get; set; }

        public static GatewayUser Create(string firstName, string lastName, string email, string userName, long id, string passwordHash = null) => new GatewayUser
        {
            Id = id,
            FirstName = firstName,
            LastName = lastName,
            Email = email,
            UserName = userName,
            PasswordHash = passwordHash
        };

        public long GetId() => Id;
    }
}
