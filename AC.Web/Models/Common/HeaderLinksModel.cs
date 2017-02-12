using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AC.Web.Models.Common
{
    public partial class HeaderLinksModel
    {
        public bool IsAuthenticated { get; set; }
        public string CustomerEmailUsername { get; set; }

        public bool ShoppingCartEnabled { get; set; }
        public int ShoppingCartItems { get; set; }

        public bool WishlistEnabled { get; set; }
        public int WishlistItems { get; set; }
        
        public bool AllowPrivateMessages { get; set; }
        public string UnreadPrivateMessages { get; set; }
        public string AlertMessage { get; set; }
    }
}