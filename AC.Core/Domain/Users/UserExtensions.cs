using System;
using System.Linq;
using AC.Core.Domain.Common;

namespace AC.Core.Domain.Users
{
    public static class UserExtensions
    {
        #region Роль юзера 

        public static bool IsInUserRole(this User user, string userRoleSystemName, bool onlyActiveUserRoles = true)
        {
            if(user == null)
                throw new ArgumentNullException("user");

            if(String.IsNullOrEmpty(userRoleSystemName))
                throw new ArgumentNullException("userRoleSystemName");

            var result = user.UserRoles
                             .FirstOrDefault(
                                 ur => (!onlyActiveUserRoles || ur.Active) && (ur.SystemName == userRoleSystemName)) !=
                         null;

            return result;
        }

        public static bool IsAdmin(this User user, bool onlyActiveUserRoles = true)
        {
            return IsInUserRole(user, SystemUserRoleNames.Administrators, onlyActiveUserRoles);
        }

        public static bool IsGuest(this User user, bool onlyActiveUserRoles = true)
        {
            return IsInUserRole(user, SystemUserRoleNames.Guests, onlyActiveUserRoles);
        }

        public static bool IsRegistered(this User user, bool onlyActiveUserRoles = true)
        {
            return IsInUserRole(user, SystemUserRoleNames.Registered, onlyActiveUserRoles);
        }

        #endregion
    }
}
