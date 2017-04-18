using System;
using AC.Core.Domain.Users;

namespace AC.Services.Users
{
    public partial interface IUserService
    {
        User GetUserById(int userId);

        User GetUserByGuid(Guid userGuid);
        
        User GetUserByUsername(string username);

        User InsertGuestUser();

        void UpdateUser(User user);
    }
}
