using AC.Core.Domain.Users;

namespace AC.Services.Users
{
    public class UserRegistrationRequest
    {
        public UserRegistrationRequest(User user, string email, string username,
            string password,
            PasswordFormat passwordFormat,
            bool isApproved = true)
        {
            this.User = user;
            this.Email = email;
            this.Username = username;
            this.Password = password;
            this.PasswordFormat = passwordFormat;
            this.IsApproved = isApproved;
        }

        public User User { get; set; }

        public string Email { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public PasswordFormat PasswordFormat { get; set; }

        public bool IsApproved { get; set; }
    }
}
