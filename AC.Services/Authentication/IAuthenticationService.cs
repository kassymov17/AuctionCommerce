using AC.Core.Domain.Users;

namespace AC.Services.Authentication
{
    public partial interface IAuthenticationService
    {
        // void SignIn(User user, bool createPersistentCookie);

        // void SignOut();

        User GetAuthenticatedUser();
    }
}
