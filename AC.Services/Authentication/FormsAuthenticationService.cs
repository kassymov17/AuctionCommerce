using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Security;
using AC.Core.Domain.Users;
using AC.Services.Users;

namespace AC.Services.Authentication
{
    public partial class FormsAuthenticationService : IAuthenticationService
    {
        #region Поля

        private readonly HttpContextBase _httpContext;
        private readonly IUserService _userService;
        private readonly TimeSpan _expirationTimeSpan;

        private User _cachedUser;

        #endregion

        #region Конструктор

        public FormsAuthenticationService(HttpContextBase httpContext,
           IUserService userService)
        {
            this._httpContext = httpContext;
            this._userService = userService;
            this._expirationTimeSpan = FormsAuthentication.Timeout;
        }

        #endregion

        protected virtual User GetAuthenticatedUserFromTicket(FormsAuthenticationTicket ticket)
        {
            if (ticket == null)
                throw new ArgumentNullException("ticket");

            var usernameOrEmail = ticket.UserData;

            if (String.IsNullOrWhiteSpace(usernameOrEmail))
                return null;
            var user = _userService.GetUserByEmail(usernameOrEmail);
            return user;
        }

        public virtual User GetAuthenticatedUser()
        {
            if (_cachedUser != null)
                return _cachedUser;

            if (_httpContext == null ||
                _httpContext.Request == null ||
                !_httpContext.Request.IsAuthenticated ||
                !(_httpContext.User.Identity is FormsIdentity))
            {
                return null;
            }

            var formsIdentity = (FormsIdentity)_httpContext.User.Identity;
            var customer = GetAuthenticatedUserFromTicket(formsIdentity.Ticket);
            if (customer != null && customer.Active && !customer.Deleted && customer.IsRegistered())
                _cachedUser = customer;
            return _cachedUser;
        }

        public virtual void SignOut()
        {
            _cachedUser = null;
            FormsAuthentication.SignOut();
        }

        public virtual void SignIn(User user, bool createPersistentCookie)
        {
            var now = DateTime.UtcNow.ToLocalTime();

            var ticket = new FormsAuthenticationTicket(
                1 /*version*/,
                user.Email,
                now,
                now.Add(_expirationTimeSpan),
                createPersistentCookie,
                user.Email,
                FormsAuthentication.FormsCookiePath);

            var encryptedTicket = FormsAuthentication.Encrypt(ticket);

            var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
            cookie.HttpOnly = true;
            if (ticket.IsPersistent)
            {
                cookie.Expires = ticket.Expiration;
            }
            cookie.Secure = FormsAuthentication.RequireSSL;
            cookie.Path = FormsAuthentication.FormsCookiePath;
            if (FormsAuthentication.CookieDomain != null)
            {
                cookie.Domain = FormsAuthentication.CookieDomain;
            }

            _httpContext.Response.Cookies.Add(cookie);
            _cachedUser = user;
        }
    }
}
