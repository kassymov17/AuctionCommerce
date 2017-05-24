using System;
using System.Collections.Generic;
using AC.Core.Domain.Catalog;
using AC.Core.Domain.Orders;

namespace AC.Core.Domain.Users
{
    public partial class User : BaseEntity
    {
        // [todo] товары, адреса, роли и тд
        
        // список вещей принадлежащих юзеру
        private ICollection<Item> _items;
        private ICollection<Bid> _bids;
        private ICollection<ProxyBid> _proxyBids;
        // список товаров в корзине
        private ICollection<ShoppingCartItem> _shoppingCartItems;

        // роли
        private ICollection<UserRole> _userRoles;
        
        public User()
        {
            this.UserGuid = Guid.NewGuid();
            this.PasswordFormat = PasswordFormat.Clear;
        }

        public Guid UserGuid { get; set; }

        public string Username { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public int PasswordFormatId { get; set; }

        public PasswordFormat PasswordFormat
        {
            get { return (PasswordFormat)PasswordFormatId; }
            set { this.PasswordFormatId = (int)value; }
        }

        public string PasswordSalt { get; set; }

        public bool HasShoppingCartItems { get; set; }

        public bool Active { get; set; }

        public bool Deleted { get; set; }

        public DateTime CreatedOnUtc { get; set; }

        public DateTime LastActivityDateUtc { get; set; }

        #region Связи


        public virtual ICollection<ShoppingCartItem> ShoppingCartItems
        {
            get { return _shoppingCartItems ?? (_shoppingCartItems = new List<ShoppingCartItem>()); }
            protected set { _shoppingCartItems = value; }
        }

        public virtual ICollection<UserRole> UserRoles
        {
            get { return _userRoles ?? (_userRoles = new List<UserRole>()); }
            protected set { _userRoles = value; }
        }

        public virtual ICollection<Item> Items
        {
            get { return _items ?? (_items = new List<Item>()); }
            protected set { _items = value; }
        }

        public virtual ICollection<Bid> Bids
        {
            get { return _bids ?? (_bids = new List<Bid>()); }
            protected set { _bids = value; }
        }

        public virtual ICollection<ProxyBid> ProxyBids
        {
            get { return _proxyBids ?? (_proxyBids = new List<ProxyBid>()); }
            protected set { _proxyBids = value; }
        }

        #endregion

    }
}
