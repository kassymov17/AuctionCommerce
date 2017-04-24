using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AC.Core;
using AC.Core.Domain.Users;
using AC.Services.Authentication;
using AC.Services.Common;
using AC.Services.Localization;
using AC.Services.Orders;
using AC.Services.Users;
using AC.Web.Models.User;

namespace AC.Web.Controllers
{
    public partial class UserController : BasePublicController
    {
        #region Поля

        private readonly IAuthenticationService _authenticationService;
        private readonly ILocalizationService _localizationService;
        private readonly IWorkContext _workContext;
        private readonly IUserService _userService;
        private readonly IShoppingCartService _shoppingCartService;
        private readonly IUserRegistrationService _userRegistrationService;
        private readonly IGenericAttributeService _genericAttributeService;

        #endregion

        #region Конструктор

        public UserController(IUserRegistrationService userRegistrationService, IGenericAttributeService genericAttributeService, IAuthenticationService authenticationService, ILocalizationService localizationService, IWorkContext workContext, IUserService userService, IShoppingCartService shoppingCartService)
        {
            _userRegistrationService = userRegistrationService;
            _authenticationService = authenticationService;
            _localizationService = localizationService;
            _workContext = workContext;
            _userService = userService;
            _shoppingCartService = shoppingCartService;
            _genericAttributeService = genericAttributeService;
        }

        #endregion

        #region Вспомогательные методы

        [NonAction]
        protected virtual void PrepareUserRegisterModel(RegisterModel model)
        {
            if(model == null)
                throw new ArgumentNullException("model");

            model.CityEnabled = false;
            model.CityRequired = false;
            model.PhoneEnabled = true;
            model.PhoneRequired = false;
            model.DisplayCaptcha = false;
        }

        [NonAction]
        protected virtual void PrepareUserInfoModel(UserInfoModel model, User user)
        {
            
        }

        #endregion

        #region Методы

        public ActionResult Register()
        {
            var model = new RegisterModel();

            PrepareUserRegisterModel(model);

            return View(model);
        }

        [HttpPost]
        public ActionResult Register(RegisterModel model, string returnUrl, FormCollection form)
        {
            if (_workContext.CurrentUser.IsRegistered())
            {
                //Already registered customer. 
                _authenticationService.SignOut();

                //Save a new record
                _workContext.CurrentUser = _userService.InsertGuestUser();
            }

            var user = _workContext.CurrentUser;

            if (ModelState.IsValid)
            {
                if (model.Username != null)
                    model.Username = model.Username.Trim();

                var registrationRequest = new UserRegistrationRequest(user,
                    model.Email,
                    model.Email,
                    model.Password,
                    PasswordFormat.Hashed,
                    true);
                var registrationResult = _userRegistrationService.RegisterUser(registrationRequest);
                if (registrationResult.Success)
                {
                    _genericAttributeService.SaveAttribute(user, SystemUserAttributeNames.Gender, model.Gender);
                    _genericAttributeService.SaveAttribute(user, SystemUserAttributeNames.FirstName, model.FirstName);
                    _genericAttributeService.SaveAttribute(user, SystemUserAttributeNames.LastName, model.LastName);

                    _authenticationService.SignIn(user, true);

                    // TODO регистрация через email
                    // стандартная регистрация
                    var redirectToResult = Url.RouteUrl("RegisterResult");
                    return Redirect(redirectToResult);
                }

                // ошибки
                foreach(var error in registrationResult.Errors)
                    ModelState.AddModelError("", error);
            }

            PrepareUserRegisterModel(model);
            return View(model);
        }

        public ActionResult RegisterResult(int resultId = 1)
        {
            var resultText = _localizationService.GetResource("Account.Register.Result.Standard");
            var model = new RegisterResultModel
            {
                Result = resultText
            };

            return View(model);
        }

        [HttpPost]
        public ActionResult RegisterResult()
        {
            return RedirectToRoute("HomePage");
        }

        public ActionResult Login()
        {
            var model = new LoginModel();
            return View(model);
        }

        [HttpPost]
        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var loginResult = _userRegistrationService.ValidateUser(model.Email, model.Password);

                switch (loginResult)
                {
                    case UserLoginResults.Successful:
                    {
                        var user = _userService.GetUserByEmail(model.Email);
                        
                        _authenticationService.SignIn(user, model.RememberMe);

                        return RedirectToRoute("HomePage");
                    }
                    case UserLoginResults.NotRegistered:
                        ModelState.AddModelError("", _localizationService.GetResource("Account.Login.WrongCredentials.NotRegistered"));
                        break;
                    case UserLoginResults.UserNotExist:
                        ModelState.AddModelError("", _localizationService.GetResource("Account.Login.WrongCredentials.UserNotExist"));
                        break;
                    case UserLoginResults.Deleted:
                        ModelState.AddModelError("", _localizationService.GetResource("Account.Login.WrongCredentials.Deleted"));
                        break;
                    case UserLoginResults.NotActive:
                        ModelState.AddModelError("", _localizationService.GetResource("Account.Login.WrongCredentials.NotActive"));
                        break;
                    case UserLoginResults.WrongPassword:
                    default: 
                        ModelState.AddModelError("", _localizationService.GetResource("Account.Login.WrongCredentials"));
                        break;
                }
            }

            return View(model);
        }

        public ActionResult Info()
        {
            if(!_workContext.CurrentUser.IsRegistered())
                return new HttpUnauthorizedResult();

            var user = _workContext.CurrentUser;

            var model = new UserInfoModel();
            PrepareUserInfoModel(model, user);

            return View(model);
        } 

        #endregion
    }
}