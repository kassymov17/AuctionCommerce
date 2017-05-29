using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using AC.Core;
using AC.Core.Domain.Catalog;
using AC.Core.Domain.Orders;
using AC.Core.Domain.Users;
using AC.Data.Abstract;
using AC.Services.Catalog;
using AC.Services.Localization;
using AC.Services.Users;

namespace AC.Services.Orders
{
    public partial class ShoppingCartService : IShoppingCartService
    {
        #region Поля

        private readonly IRepository<ShoppingCartItem> _sciRepository;
        private readonly IWorkContext _workContext;
        private readonly IItemService _itemService;
        private readonly ILocalizationService _localizationService;
        private readonly IUserService _userService;
        private readonly IRepository<Bid> _bidRepository;
        private readonly IRepository<ProxyBid> _proxyBidRepository;

        #endregion

        #region Конструктор

        public ShoppingCartService(IRepository<ShoppingCartItem> sciRepository, IWorkContext workContext,
            IItemService itemService, ILocalizationService localizationService, IUserService userService,
            IRepository<Bid> bidRepository, IRepository<ProxyBid> proxyBidRepository)
        {
            _sciRepository = sciRepository;
            _workContext = workContext;
            _itemService = itemService;
            _localizationService = localizationService;
            _userService = userService;
            _bidRepository = bidRepository;
            _proxyBidRepository = proxyBidRepository;
        }

        #endregion

        #region Методы

        public virtual ShoppingCartItem FindShoppingCartItemInTheCart(IList<ShoppingCartItem> shoppingCart,
            ShoppingCartType shoppingCartType,
            Item item)
        {
            if (shoppingCart == null)
                throw new ArgumentNullException("shoppingCart");

            if (item == null)
                throw new ArgumentNullException("item");

            foreach (var sci in shoppingCart.Where(a => a.ShoppingCartType == shoppingCartType))
            {
                if (sci.ItemId == item.Id)
                {
                    return sci;
                }
            }

            return null;
        }

        public virtual IList<string> GetShoppingCartItemWarnings(User user, ShoppingCartType shoppingCartType,
            Item item, int quantity = 1, bool getStandardWarnings = true)
        {
            if(item == null)
                throw new ArgumentNullException("item");

            var warnings = new List<string>();

            if (getStandardWarnings)
            {
                warnings.AddRange(GetStandardWarnings(user, shoppingCartType, item, quantity));
            }

            return warnings;
        }

        public virtual IList<string> AddToCart(User user, Item item, ShoppingCartType shoppingCartType, int quantity = 1)
        {
            if(user == null)
                throw new ArgumentNullException("user");

            if (item == null)
                throw new ArgumentNullException("item");

            var warnings = new List<string>();

            if (quantity <= 0)
            {
                warnings.Add(_localizationService.GetResource("ShoppingCart.QuantityShouldPositive"));
                return warnings;
            }

            var cart = user.ShoppingCartItems
                .Where(sci => sci.ShoppingCartType == shoppingCartType)
                .ToList();

            var shoppingCartItem = FindShoppingCartItemInTheCart(cart, shoppingCartType, item);

            if (shoppingCartItem != null)
            {
                // обновить существующий товар
                int newQuantity = shoppingCartItem.Quantity + quantity;
                warnings.AddRange(GetShoppingCartItemWarnings(user, shoppingCartType, item, newQuantity));

                if (!warnings.Any())
                {
                    shoppingCartItem.Quantity = newQuantity;
                    shoppingCartItem.UpdatedOnUtc = DateTime.UtcNow;
                    _userService.UpdateUser(user);
                }
            }
            else
            {
                // новый товар в корзине
                warnings.AddRange(GetShoppingCartItemWarnings(user, shoppingCartType, item, quantity));

                if (!warnings.Any())
                {
                    switch (shoppingCartType)
                    {
                        case ShoppingCartType.ShoppingCart:
                            {
                                if (cart.Count >= 17)
                                {
                                    warnings.Add(string.Format(_localizationService.GetResource("ShoppingCart.MaximumShoppingCartItems"), 17));
                                    return warnings;
                                }   
                            }
                            break;
                        case ShoppingCartType.Wishlist:
                            {
                                if (cart.Count >= 17)
                                {
                                    warnings.Add(string.Format(_localizationService.GetResource("ShoppingCart.MaximumWishlistItems"), 17));
                                    return warnings;
                                }
                            }
                            break;
                        default:
                            break;
                    }

                    DateTime now = DateTime.UtcNow;
                    shoppingCartItem = new ShoppingCartItem
                    {
                        ShoppingCartType = shoppingCartType,
                        Item =  item,
                        Quantity = quantity,
                        CreatedOnUtc = now,
                        UpdatedOnUtc = now
                    };
                    user.ShoppingCartItems.Add(shoppingCartItem);
                    _userService.UpdateUser(user);

                    user.HasShoppingCartItems = user.ShoppingCartItems.Any();
                    _userService.UpdateUser(user);
                }
            }
            return warnings;
        }

        public virtual IList<string> GetStandardWarnings(User user, ShoppingCartType shoppingCartType, Item item, int quantity)
        {
            if(user == null)
                throw new ArgumentNullException("user");

            if (item == null)
                throw new ArgumentNullException("item");

            var warnings = new List<string>();

            // удален 
            if (item.Deleted)
            {
                warnings.Add(_localizationService.GetResource("ShoppingCart.ProductDeleted"));
            }

            // не опубликован
            if (!item.Published)
            {
                warnings.Add(_localizationService.GetResource("ShoppingCart.ProductUnpublished"));
            }

            // время торгов окончено
            bool availableStartDateError = false;
            if (item.AuctionStartDate.HasValue)
            {
                DateTime now = DateTime.UtcNow;
                DateTime availableStartDateTime = DateTime.SpecifyKind(item.AuctionStartDate.Value, DateTimeKind.Utc);
                if (availableStartDateTime.CompareTo(now) > 0)
                {
                    warnings.Add(_localizationService.GetResource("ShoppingCart.NotAvailable"));
                    availableStartDateError = true;
                }
            }
            if (item.AuctionEndDate.HasValue && !availableStartDateError)
            {
                DateTime now = DateTime.UtcNow;
                DateTime availableEndDateTime = DateTime.SpecifyKind(item.AuctionEndDate.Value, DateTimeKind.Utc);
                if (availableEndDateTime.CompareTo(now) < 0)
                {
                    warnings.Add(_localizationService.GetResource("ShoppingCart.NotAvailable"));
                }
            }

            return warnings;
        }

        public virtual IList<string> PlaceBid(User user, Item item, decimal userEnteredPrice = decimal.Zero)
        {
            if (user == null)
                throw new ArgumentNullException("user");

            if (item == null)
                throw new ArgumentNullException("item");

            var warnings = new List<string>();

            if (userEnteredPrice <= 0)
            {
                warnings.Add(_localizationService.GetResource("ShoppingCart.EnteredPriceShouldPositive"));
                return warnings;
            }

            if (userEnteredPrice < item.InitialPrice + item.BidStep)
            {
                warnings.Add(_localizationService.GetResource("ShoppingCart.EnteredPriceShouldBeMoreThanInitial"));
                return warnings;
            }
            // todo переписать в AC.Services
            decimal highBid;
            
            var winningBid = _bidRepository.Table.Where(b => b.ItemId == item.Id).OrderByDescending(b => b.Amount).FirstOrDefault();
            var winningBidder = winningBid == null ? null : winningBid.User;

            var bid = item.InitialPrice + item.BidStep;
            var biddingEnded = false;
            if (winningBidder == user)
            {
                var proxyBid =
                    _proxyBidRepository.Table.Where(p => p.UserId == user.Id && p.ItemId == item.Id)
                        .OrderByDescending(p => p.Bid)
                        .FirstOrDefault();
                if (proxyBid != null)
                {
                    var winnerProxyBid = proxyBid.Bid;
                    if (winnerProxyBid >= userEnteredPrice)
                    {
                        warnings.Add("Ваша предыдущая ставка была выше текущей");
                        return warnings;
                    }
                    else
                    {
                        // обновить максимальную ставку
                        proxyBid.Bid = userEnteredPrice;
                        _proxyBidRepository.Update(proxyBid);

                        // добавить ставку todo продумать с резервной ценой
                        biddingEnded = true;
                    }
                }
            }
            if (!biddingEnded)
            {
                var proxyBidQuery =
                    _proxyBidRepository.Table.Where(p => p.ItemId == item.Id)
                        .OrderByDescending(p => p.Bid)
                        .FirstOrDefault();
                if (proxyBidQuery == null) // первая ставка
                {
                    _proxyBidRepository.Insert(new ProxyBid
                    {
                        User = user,
                        Item = item,
                        Bid = userEnteredPrice
                    });

                    _bidRepository.Insert(new Bid
                    {
                        User = user,
                        Item = item,
                        Amount = bid,
                        CreatedOn = DateTime.UtcNow
                    });

                    // обновить цену лота
                    item.InitialPrice = bid;
                    _itemService.UpdateItem(item);
                }
                else // не первая ставка
                {
                    var proxyBidder = proxyBidQuery.User;
                    var proxyMaxBid = proxyBidQuery.Bid;

                    if (proxyMaxBid < userEnteredPrice)
                    {
                        if (proxyBidder != user)
                        {
                            // отправить уведомление пользователю, чью ставку сбили
                        }
                        var nextBid = proxyMaxBid + item.BidStep;
                        if (nextBid > userEnteredPrice)
                            nextBid = userEnteredPrice;

                        var proxyBidData =
                            _proxyBidRepository.Table.FirstOrDefault(p => p.ItemId == item.Id && p.UserId == user.Id);
                        if (proxyBidData == null)
                        {
                            _proxyBidRepository.Insert(new ProxyBid
                            {
                                Item = item,
                                User = user,
                                Bid = userEnteredPrice
                            });
                        }
                        else
                        {
                            proxyBidData.Bid = userEnteredPrice;
                            _proxyBidRepository.Update(proxyBidData);
                        }

                        // левые стаки для отображения последовательных ставок
                        if (item.InitialPrice < proxyMaxBid)
                        {
                            _bidRepository.Insert(new Bid
                            {
                                User = proxyBidder,
                                Item = item,
                                Amount = proxyMaxBid,
                                CreatedOn = DateTime.UtcNow
                            });
                        }

                        _bidRepository.Insert(new Bid
                        {
                            User = user,
                            Item = item,
                            Amount = nextBid,
                            CreatedOn = DateTime.UtcNow
                        });

                        item.InitialPrice = nextBid;
                        _itemService.UpdateItem(item);
                    }
                    else if (proxyMaxBid == userEnteredPrice)
                    {
                        _bidRepository.Insert(new Bid
                        {
                            User = proxyBidQuery.User,
                            Item = item,
                            Amount = proxyMaxBid,
                            CreatedOn = DateTime.Now
                        });

                        _bidRepository.Insert(new Bid
                        {
                            User = user,
                            Item = item,
                            Amount = userEnteredPrice,
                            CreatedOn = DateTime.Now
                        });
                        
                        item.InitialPrice = userEnteredPrice;
                        _itemService.UpdateItem(item);
                    }
                    else if (proxyMaxBid > userEnteredPrice)
                    {
                        _bidRepository.Insert(new Bid()
                        {
                            Item = item,
                            User = user,
                            CreatedOn = DateTime.Now,
                            Amount = userEnteredPrice
                        });
                        decimal cBid;
                        if (userEnteredPrice + item.BidStep - proxyMaxBid >= 0)
                        {
                            cBid = proxyMaxBid;
                        }
                        else
                        {
                            cBid = userEnteredPrice + item.BidStep;
                        }

                        warnings.Add("Ваша ставка не является максимальной. Попробуйте еще раз");

                        _bidRepository.Insert(new Bid
                        {
                            Item = item,
                            User = proxyBidder,
                            Amount = cBid,
                            CreatedOn = DateTime.Now
                        });

                        item.InitialPrice = cBid;
                        _itemService.UpdateItem(item);
                    }
                }
            }
            return warnings;
        }

        #endregion
    }
}
