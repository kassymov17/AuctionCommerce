using AC.Core;
using AC.Core.Domain.Localization;
using AC.Core.Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc.Filters;
using AC.Services.Authentication;
using AC.Services.Common;
using AC.Services.Localization;
using AC.Services.Users;

namespace AC.Web.Framework
{
    public partial class WebWorkContext : IWorkContext
    {
        #region Const

        private const string UserCookieName = "AC.user";

        #endregion

        #region Fields

        private readonly HttpContextBase _httpContext;
        private readonly IAuthenticationService _authenticationService;
        private readonly IUserService _userService;
        private readonly IGenericAttributeService _genericAttributeService;
        private readonly ILanguageService _languageService;

        private User _cachedUser;
        private User _originalUserIfImpersonated;
        private Language _cachedLanguage;

        #endregion
        public WebWorkContext(HttpContextBase httpContext, ILanguageService languageService, IAuthenticationService authenticationService, IUserService userService, IGenericAttributeService genericAttributeService)
        {
            _httpContext = httpContext;
            _authenticationService = authenticationService;
            _userService = userService;
            _genericAttributeService = genericAttributeService;
            _languageService = languageService;
        }

        protected virtual HttpCookie GetUserCookie()
        {
            if (_httpContext == null || _httpContext.Request == null)
                return null;

            return _httpContext.Request.Cookies[UserCookieName];
        }

        protected virtual void SetUserCookie(Guid userGuid)
        {
            if (_httpContext != null && _httpContext.Response != null)
            {
                var cookie = new HttpCookie(UserCookieName);
                cookie.HttpOnly = true;
                cookie.Value = userGuid.ToString();
                if (userGuid == Guid.Empty)
                {
                    cookie.Expires = DateTime.Now.AddMonths(-1);
                }
                else
                {
                    int cookieExpires = 24 * 365;
                    cookie.Expires = DateTime.Now.AddHours(cookieExpires);
                }

                _httpContext.Response.Cookies.Remove(UserCookieName);
                _httpContext.Response.Cookies.Add(cookie);
            }    
        }

        public virtual User CurrentUser
        {
            get
            {
                if (_cachedUser != null)
                    return _cachedUser;

                User user = null;
                
                // зарегистрированный пользователь
                if (user == null || user.Deleted || !user.Active)
                {
                    user = _authenticationService.GetAuthenticatedUser();
                }

                if (user != null && !user.Deleted && user.Active)
                {
                    var impersonatedUserId = user.GetAttribute<int?>(SystemUserAttributeNames.ImpersonatedUserId);
                    /* [todo] user service
                    if (impersonatedUserId.HasValue && impersonatedUserId.Value > 0)
                    {
                        var impersonatedUser = _userService.GetUserById(impersonatedUserId.Value);
                        if (impersonatedUser != null && !impersonatedUser.Deleted && impersonatedUser.Active)
                        {
                            _originalUserIfImpersonated = user;
                            user = impersonatedUser;
                        }
                    }
                    */
                }

                if (user == null || user.Deleted || !user.Active)
                {
                    var userCookie = GetUserCookie();
                    if (userCookie != null && !String.IsNullOrEmpty(userCookie.Value))
                    {
                        Guid userGuid;
                        if (Guid.TryParse(userCookie.Value, out userGuid))
                        {
                            var userByCookie = _userService.GetUserByGuid(userGuid);
                            if (userByCookie != null && !userByCookie.IsRegistered())
                                user = userByCookie;
                        }
                    }
                }

                if (user == null || user.Deleted || !user.Active)
                    user = _userService.InsertGuestUser();

                if (!user.Deleted && user.Active)
                {
                    SetUserCookie(user.UserGuid);
                    _cachedUser = user;
                }

                return _cachedUser;
            }
            set
            {
                SetUserCookie(value.UserGuid);
                _cachedUser = value;
            }
            
        }

        public virtual Language WorkingLanguage
        {
            get
            {
                if(_cachedLanguage != null)
                    return _cachedLanguage;
                Language detectedLanguage = null;
                if (detectedLanguage == null)
                {
                    // получить язык из настроек браузера
                    if (!this.CurrentUser.GetAttribute<bool>(SystemUserAttributeNames.LanguageAutomaticallyDetected,
                        _genericAttributeService))
                    {
                        detectedLanguage = GetLanguageFromBrowserSettings();
                        if (detectedLanguage != null)
                        {
                            _genericAttributeService.SaveAttribute(this.CurrentUser, SystemUserAttributeNames.LanguageAutomaticallyDetected,
                                true);    
                        }
                    }
                }
                if (detectedLanguage != null)
                {
                    // сохраняем язык
                    if (this.CurrentUser.GetAttribute<int>(SystemUserAttributeNames.LanguageId, _genericAttributeService) !=
                        detectedLanguage.Id)
                    {
                        _genericAttributeService.SaveAttribute(this.CurrentUser, SystemUserAttributeNames.LanguageId, detectedLanguage.Id);
                    }
                }

                var allLanguages = _languageService.GetAllLanguages();
                var languageId = this.CurrentUser.GetAttribute<int>(SystemUserAttributeNames.LanguageId,
                    _genericAttributeService);
                var language = allLanguages.FirstOrDefault(l => l.Id == languageId);

                if (language == null)
                {
                    // грузим русский язык по умолчанию
                    language = allLanguages.FirstOrDefault(x => x.Id == 1);
                }
                if (language == null)
                {
                    language = allLanguages.FirstOrDefault();
                }
                if (language == null)
                {
                    language = _languageService.GetAllLanguages().FirstOrDefault();
                }

                _cachedLanguage = language;
                return _cachedLanguage;
            }
            set
            {
                var languageId = value != null ? value.Id : 0;
                _genericAttributeService.SaveAttribute(this.CurrentUser, SystemUserAttributeNames.LanguageId, languageId);

                _cachedLanguage = null;
            }
        }

        protected virtual Language GetLanguageFromBrowserSettings()
        {
            if (_httpContext == null ||
                _httpContext.Request == null ||
                _httpContext.Request.UserLanguages == null)
                return null;

            var userLanguage = _httpContext.Request.UserLanguages.FirstOrDefault();
            if (String.IsNullOrEmpty(userLanguage))
                return null;

            var language = _languageService
                .GetAllLanguages()
                .FirstOrDefault(l => userLanguage.Equals(l.LanguageCulture, StringComparison.InvariantCultureIgnoreCase));

            if (language != null && language.Published)
            {
                return language;
            }

            return null;
        }

        public virtual User OriginalUserIfImpersonated
        {
            get { return _originalUserIfImpersonated; }
        }

        public virtual bool IsAdmin { get; set; }
    }
}
