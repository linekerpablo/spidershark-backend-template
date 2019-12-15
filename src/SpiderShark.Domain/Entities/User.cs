namespace SpiderShark.Domain.Entities
{
    public class User
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string PasswordHash { get; set; }

        public static User Create(string firstName, string lastName, string email, string userName, long id, string passwordHash = null) => new User
        {
            Id = id,
            FirstName = firstName,
            LastName = lastName,
            Email = email,
            UserName = userName,
            PasswordHash = passwordHash
        };

        public long GetId() => Id;

        public string GetUserName() => UserName;

        public string GetEmail() => Email;
    }
}
