using AC.Services.Localization;
using AC.Web.Framework.Validators;
using AC.Web.Models.User;
using FluentValidation;

namespace AC.Web.Validators.User
{
    public partial class LoginValidator : BaseACValidator<LoginModel>
    {
        public LoginValidator(ILocalizationService localizationService)
        {
            RuleFor(x => x.Email).NotEmpty().WithMessage(localizationService.GetResource("Account.Login.Fields.Email.Required"));
            RuleFor(x => x.Email).EmailAddress().WithMessage(localizationService.GetResource("Common.WrongEmail"));
        }
    }
}