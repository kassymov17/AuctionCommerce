using System;
using System.Linq;
using AC.Core;
using AC.Core.Domain.Users;
using AC.Services.Localization;
using AC.Services.Security;

namespace AC.Services.Users
{
    public partial class UserRegistrationService : IUserRegistrationService
    {
        #region Поля 

        private readonly ILocalizationService _localizationService;
        private readonly IEncryptionService _encryptionService;
        private readonly IUserService _userService;

        #endregion

        #region Кнстр

        public UserRegistrationService(ILocalizationService localizationService, IEncryptionService encryptionService, IUserService userService)
        {
            _localizationService = localizationService;
            _encryptionService = encryptionService;
            _userService = userService;
        }

        #endregion

        public virtual UserRegistrationResult RegisterUser(UserRegistrationRequest request)
        {
            if (request == null)
                throw new ArgumentNullException("request");

            if (request.User == null)
                throw new ArgumentException("Не могу загрузить юзера");

            var result = new UserRegistrationResult();

            if (request.User.IsRegistered())
            {
                result.AddError("Пользователь уже зарегистрирован");
                return result;
            }

            if (String.IsNullOrEmpty(request.Email))
            {
                result.AddError(_localizationService.GetResource("Account.Register.Errors.EmailIsNotProvided"));
                return result;
            }

            if (!CommonHelper.IsValidEmail(request.Email))
            {
                result.AddError(_localizationService.GetResource("Common.WrongEmail"));
                return result;
            }

            if (String.IsNullOrWhiteSpace(request.Password))
            {
                result.AddError(_localizationService.GetResource("Account.Register.Errors.PasswordIsNotProvided"));
                return result;
            }

            if (_userService.GetUserByEmail(request.Email) != null)
            {
                result.AddError(_localizationService.GetResource("Account.Register.Errors.EmailAlreadyExists"));
                return result;
            }

            request.User.Username = request.Username;
            request.User.Email = request.Email;
            request.User.PasswordFormat = request.PasswordFormat;

            switch (request.PasswordFormat)
            {
                case PasswordFormat.Clear:
                    {
                        request.User.Password = request.Password;
                    }
                    break;
                case PasswordFormat.Hashed:
                    {
                        string saltKey = _encryptionService.CreateSaltKey(5);
                        request.User.PasswordSalt = saltKey;
                        request.User.Password = _encryptionService.CreatePasswordHash(request.Password, saltKey, "SHA1");
                    }
                    break;
                default:
                    break;
            }

            request.User.Active = request.IsApproved;

            var registeredRole = _userService.GetUserRoleBySystemName(SystemUserRoleNames.Registered);

            if (registeredRole == null)
                throw new Exception("'Registered' role could not be loaded");

            request.User.UserRoles.Add(registeredRole);

            // удалить роль гость
            var guestRole = request.User.UserRoles.FirstOrDefault(ur => ur.SystemName == SystemUserRoleNames.Guests);
            if (guestRole != null)
                request.User.UserRoles.Remove(guestRole);

            _userService.UpdateUser(request.User);
            return result;
        }

        public virtual UserLoginResults ValidateUser(string email, string password)
        {
            var user = _userService.GetUserByEmail(email);

            if(user == null)
                return UserLoginResults.UserNotExist;

            if(user.Deleted)
                return UserLoginResults.Deleted;

            if(!user.Active)
                return UserLoginResults.NotActive;

            if(!user.IsRegistered())
                return UserLoginResults.NotRegistered;

            var pwd = _encryptionService.CreatePasswordHash(password, user.PasswordSalt);

            bool isValid = pwd == user.Password;
            if(!isValid)
                return UserLoginResults.WrongPassword;

            return UserLoginResults.Successful;
        }
    }
}
