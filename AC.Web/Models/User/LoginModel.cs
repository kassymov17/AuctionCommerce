using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using AC.Web.Framework;
using FluentValidation.Attributes;
using AC.Web.Validators.User;

namespace AC.Web.Models.User
{
    [Validator(typeof(LoginValidator))]
    public partial class LoginModel
    {
        [ACResourceDisplayName("Account.Login.Fields.Email")]
        [AllowHtml]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        [ACResourceDisplayName("Account.Login.Fields.Password")]
        [AllowHtml]
        public string Password { get; set; }

        [ACResourceDisplayName("Account.Login.Fields.RememberMe")]
        public bool RememberMe { get; set; }
    }
}