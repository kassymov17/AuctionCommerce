using System.Collections.Generic;
using AC.Web.Framework.Mvc;

namespace AC.Web.Models.User
{
    public partial class UserNavigationModel
    {
        public UserNavigationModel()
        {
            UserNavigationItems = new List<UserNavigationItemModel>();
        }

        public IList<UserNavigationItemModel> UserNavigationItems { get; set; }

        public UserNavigationEnum SelectedTab { get; set; }
    }

    public class UserNavigationItemModel
    {
        public string RouteName { get; set; }
        public string Title { get; set; }
        public UserNavigationEnum Tab { get; set; }
        public string ItemClass { get; set; }
    }

    public enum UserNavigationEnum
    {
        Info = 0,
        AddItem = 10,
        Orders = 20,
        Bids = 30,
        Items = 40,
        WonBids = 50
    }
}