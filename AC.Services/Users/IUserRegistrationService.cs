using AC.Core.Domain.Users;

namespace AC.Services.Users
{
    public partial interface IUserRegistrationService
    {
        UserRegistrationResult RegisterUser(UserRegistrationRequest request);

        UserLoginResults ValidateUser(string email, string password);
    }
}
