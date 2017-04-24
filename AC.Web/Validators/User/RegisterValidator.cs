using System;
using System.Linq;
using FluentValidation;
using FluentValidation.Results;
using AC.Core;
using AC.Core.Domain.Users;
using AC.Services.Localization;
using AC.Web.Framework.Validators;
using AC.Web.Models.User;

namespace AC.Web.Validators.User
{
    public class RegisterValidator : BaseACValidator<RegisterModel>
    {
        public RegisterValidator(ILocalizationService localizationService)
        {
            RuleFor(x => x.Email)
                .NotEmpty()
                .WithMessage(localizationService.GetResource("Account.Fields.Email.Required"));

            RuleFor(x => x.Email).EmailAddress().WithMessage(localizationService.GetResource("Common.WrongEmail"));

            RuleFor(x => x.Username).NotEmpty().WithMessage(localizationService.GetResource("Account.Fields.Username.Required"));

            RuleFor(x => x.FirstName).NotEmpty().WithMessage(localizationService.GetResource("Account.Fields.FirstName.Required"));
            RuleFor(x => x.LastName).NotEmpty().WithMessage(localizationService.GetResource("Account.Fields.LastName.Required"));

            RuleFor(x => x.Password).NotEmpty().WithMessage(localizationService.GetResource("Account.Fields.Password.Required"));
            RuleFor(x => x.Password).Length(7, 999).WithMessage(string.Format(localizationService.GetResource("Account.Fields.Password.LengthValidation"), 7));
            RuleFor(x => x.ConfirmPassword).NotEmpty().WithMessage(localizationService.GetResource("Account.Fields.ConfirmPassword.Required"));
            RuleFor(x => x.ConfirmPassword).Equal(x => x.Password).WithMessage(localizationService.GetResource("Account.Fields.Password.EnteredPasswordsDoNotMatch"));

            Custom(x =>
            {
                var dateOfBirth = x.ParseDateOfBirth();
                //entered?
                if (!dateOfBirth.HasValue)
                {
                    return new ValidationFailure("DateOfBirthDay",
                        localizationService.GetResource("Account.Fields.DateOfBirth.Required"));
                }

                return null;
            });

            RuleFor(x => x.StreetAddress).NotEmpty().WithMessage(localizationService.GetResource("Account.Fields.StreetAddress.Required"));

            RuleFor(x => x.City).NotEmpty().WithMessage(localizationService.GetResource("Account.Fields.City.Required"));

            RuleFor(x => x.Phone).NotEmpty().WithMessage(localizationService.GetResource("Account.Fields.Phone.Required"));
            
        }
    }
}