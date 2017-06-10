using System.Collections.Generic;
using System.Web.Mvc;
using AC.Web.Framework;
using AC.Web.Framework.Mvc;

namespace AC.Web.Models.Checkout
{
    public partial class AddressModel : BaseACEntityModel
    {
        [ACResourceDisplayName("Address.Fields.FirstName")]
        [AllowHtml]
        public string FirstName { get; set; }
        [ACResourceDisplayName("Address.Fields.LastName")]
        [AllowHtml]
        public string LastName { get; set; }
        [ACResourceDisplayName("Address.Fields.Email")]
        [AllowHtml]
        public string Email { get; set; }
        [ACResourceDisplayName("Address.Fields.City")]
        [AllowHtml]
        public string City { get; set; }
        [ACResourceDisplayName("Address.Fields.Address")]
        public string Address { get; set; }
        [ACResourceDisplayName("Address.Fields.Phone")]
        [AllowHtml]
        public string Phone { get; set; }
    }
}