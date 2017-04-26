using System;
using System.Collections.Generic;
using System.Web.Mvc;
using AC.Web.Framework;

namespace AC.Web.Models.User
{
    public partial class UserInfoModel
    {
        [ACResourceDisplayName("Account.Fields.Email")]
        [AllowHtml]
        public string Email { get; set; }

        [ACResourceDisplayName("Account.Fields.Gender")]
        public string Gender { get; set; }

        [ACResourceDisplayName("Account.Fields.FirstName")]
        [AllowHtml]
        public string FirstName { get; set; }

        [ACResourceDisplayName("Account.Fields.LastName")]
        [AllowHtml]
        public string LastName { get; set; }
    }
}