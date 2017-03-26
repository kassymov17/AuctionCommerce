using System;
using System.Linq;
using AC.Core.Domain.Users;
using AC.Data.Abstract;

namespace AC.Services.Users
{
    public partial class UserService : IUserService
    {
        #region Поля

        private readonly IRepository<User> _userRepository;
        private readonly IRepository<UserRole> _userRoleRepository;

        #endregion

        #region Конструктор

        public UserService(IRepository<User> userRepository, IRepository<UserRole> userRoleRepository)
        {
            _userRepository = userRepository;
            _userRoleRepository = userRoleRepository;
        }

        #endregion

        #region Методы

        public virtual User GetUserById(int userId)
        {
            if (userId == 0)
                return null;

            return _userRepository.GetById(userId);
        }

        public virtual User GetUserByGuid(Guid userGuid)
        {
            if (userGuid == Guid.Empty)
                return null;

            var query = from u in _userRepository.Table
                where u.UserGuid == userGuid
                orderby u.Id
                select u;

            var user = query.FirstOrDefault();
            return user;
        }

        public virtual User GetUserByUsername(string username)
        {
            if (string.IsNullOrEmpty(username))
                return null;

            var query = from u in _userRepository.Table
                where u.Username == username
                orderby u.Id
                select u;

            var user = query.FirstOrDefault();
            return user;
        }

        public virtual User InsertGuestUser()
        {
            var user = new User
            {
                UserGuid = Guid.NewGuid(),
                Active = true,
                CreatedOnUtc = DateTime.UtcNow,
                LastActivityDateUtc = DateTime.UtcNow
            };

            // добавить роль гость
            var guestRole = GetUserRoleBySystemName(SystemUserRoleNames.Guests);
            if(guestRole == null)
                throw new Exception("Не могу загрузить роль 'Гость'");
            user.UserRoles.Add(guestRole);

            _userRepository.Insert(user);

            return user;
        }

        public virtual UserRole GetUserRoleBySystemName(string systemName)
        {
            if (string.IsNullOrEmpty(systemName))
                return null;

            var query = from ur in _userRoleRepository.Table
                orderby ur.Id
                where ur.SystemName == systemName
                select ur;

            var userRole = query.FirstOrDefault();
            return userRole;
        }

        #endregion

    }
}
