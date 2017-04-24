using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using AC.Web.Framework;
using AC.Web.Validators.User;
using FluentValidation.Attributes;

namespace AC.Web.Models.User
{
    [Validator(typeof(RegisterValidator))]
    public partial class RegisterModel
    {
        [ACResourceDisplayName("Account.Fields.Email")]
        [AllowHtml]
        public string Email { get; set; }

        [ACResourceDisplayName("Account.Fields.Username")]
        [AllowHtml]
        public string Username { get; set; }

        [DataType(DataType.Password)]
        [ACResourceDisplayName("Account.Fields.Password")]
        [AllowHtml]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [ACResourceDisplayName("Account.Fields.Password")]
        [AllowHtml]
        public string ConfirmPassword { get; set; }

        [ACResourceDisplayName("Account.Fields.Gender")]
        public string Gender { get; set; }

        [ACResourceDisplayName("Account.Fields.FirstName")]
        [AllowHtml]
        public string FirstName { get; set; }

        [ACResourceDisplayName("Account.Fields.LastName")]
        [AllowHtml]
        public string LastName { get; set; }

        [ACResourceDisplayName("Account.Fields.DateOfBirth")]
        public int? DateOfBirthDay { get; set; }

        [ACResourceDisplayName("Account.Fields.DateOfBirth")]
        public int? DateOfBirthMonth { get; set; }

        [ACResourceDisplayName("Account.Fields.DateOfBirth")]
        public int? DateOfBirthYear { get; set; }

        public DateTime? ParseDateOfBirth()
        {
            if (!DateOfBirthDay.HasValue || !DateOfBirthMonth.HasValue || !DateOfBirthYear.HasValue)
                return null;

            DateTime? dateOfBirth = null;

            try
            {
                dateOfBirth = new DateTime(DateOfBirthYear.Value, DateOfBirthMonth.Value, DateOfBirthDay.Value);
            }
            catch { }
            return dateOfBirth;
        }

        [ACResourceDisplayName("Account.Fields.StreetAddress")]
        [AllowHtml]
        public string StreetAddress { get; set; }

        public bool CityEnabled { get; set; }
        public bool CityRequired { get; set; }
        [ACResourceDisplayName("Account.Fields.City")]
        [AllowHtml]
        public string City { get; set; }

        public bool PhoneEnabled { get; set; }
        public bool PhoneRequired { get; set; }
        [ACResourceDisplayName("Account.Fields.Phone")]
        [AllowHtml]
        public string Phone { get; set; }

        public bool DisplayCaptcha { get; set; }
    }
}