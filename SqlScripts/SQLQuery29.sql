USE [AuctionCommerce];
SET NOCOUNT ON;
SET XACT_ABORT ON;
GO

SET IDENTITY_INSERT [dbo].[LocaleStringResource] ON;

BEGIN TRANSACTION;
INSERT INTO [dbo].[LocaleStringResource]([Id], [LanguageId], [ResourceName], [ResourceValue])
SELECT 1, 1, N'Footer.Information', N'Информация' UNION ALL
SELECT 2, 1, N'ContactUs', N'Написать нам' UNION ALL
SELECT 3, 1, N'Footer.UserService', N'Маркетинг' UNION ALL
SELECT 4, 1, N'Search', N'Поиск' UNION ALL
SELECT 5, 1, N'News', N'Новости' UNION ALL
SELECT 6, 1, N'Products.RecentlyViewedProducts', N'Просмотренные товары' UNION ALL
SELECT 7, 1, N'Products.NewProducts', N'Новинки' UNION ALL
SELECT 8, 1, N'Footer.MyAccount', N'Мой аккаунт' UNION ALL
SELECT 9, 1, N'Account.MyAccount', N'Мой кабинет' UNION ALL
SELECT 10, 1, N'Account.UserOrders', N'Мои заказы' UNION ALL
SELECT 11, 1, N'ShoppingCart', N'Корзина' UNION ALL
SELECT 12, 1, N'Wishlist', N'Избранное' UNION ALL
SELECT 14, 1, N'Categories', N'Категории' UNION ALL
SELECT 17, 1, N'Menu', N'Меню' UNION ALL
SELECT 18, 1, N'Media.Category.ImageLinkTitleFormat', N'Показать товары в категории {0}' UNION ALL
SELECT 20, 1, N'Media.Category.ImageAlternateTextFormat', N'Изображение категории {0}' UNION ALL
SELECT 21, 1, N'HomePage.Products', N'Избранные товары' UNION ALL
SELECT 23, 1, N'ShoppingCart.AddToCart', N'В корзину' UNION ALL
SELECT 25, 1, N'ShoppingCart.AddToWishlist', N'В избранное' UNION ALL
SELECT 26, 1, N'Auction.GoToDetails', N'Поставить' UNION ALL
SELECT 28, 1, N'ShoppingCart.HeaderQuantity', N'({0})' UNION ALL
SELECT 29, 1, N'Products.ProductHasBeenAddedToTheCart.Link', N'Товар был добавлен в <a href="{0}">корзину</a>' UNION ALL
SELECT 30, 1, N'Common.Notification', N'Уведомление' UNION ALL
SELECT 31, 1, N'Common.Error', N'Ошибка' UNION ALL
SELECT 32, 1, N'Common.Close', N'Закрыть' UNION ALL
SELECT 33, 1, N'Account.Fields.Email', N'Email' UNION ALL
SELECT 34, 1, N'Account.Fields.Username', N'Логин' UNION ALL
SELECT 35, 1, N'Account.Fields.Password', N'Пароль' UNION ALL
SELECT 36, 1, N'Account.Fields.Gender', N'Пол' UNION ALL
SELECT 37, 1, N'Account.Fields.FirstName', N'Имя' UNION ALL
SELECT 38, 1, N'Account.Fields.LastName', N'Фамилия' UNION ALL
SELECT 39, 1, N'Account.Fields.DateOfBirth', N'Дата рождения' UNION ALL
SELECT 40, 1, N'Account.Fields.StreetAddress', N'Адрес' UNION ALL
SELECT 41, 1, N'Account.Fields.City', N'Город' UNION ALL
SELECT 42, 1, N'Account.Fields.Phone', N'Телефон' UNION ALL
SELECT 43, 1, N'Account.Fields.Email.Required', N'Email обязательное поле' UNION ALL
SELECT 44, 1, N'Common.WrongEmail', N'Неверный email' UNION ALL
SELECT 45, 1, N'Account.Fields.Username.Required', N'Логин обязательное поле' UNION ALL
SELECT 46, 1, N'Account.Fields.FirstName.Required', N'Введите имя' UNION ALL
SELECT 47, 1, N'Account.Fields.LastName.Required', N'Введите фамилию' UNION ALL
SELECT 48, 1, N'HomePage', N'Главная' UNION ALL
SELECT 49, 1, N'Account.Register', N'Регистрация' UNION ALL
SELECT 50, 1, N'Account.YourPersonalDetails', N'Персональные данные' UNION ALL
SELECT 51, 1, N'Account.Fields.Gender.Male', N'Мужской' UNION ALL
SELECT 52, 1, N'Account.Fields.Gender.Female', N'Женский' UNION ALL
SELECT 53, 1, N'Common.Day', N'День' UNION ALL
SELECT 54, 1, N'Common.Month', N'Месяц' UNION ALL
SELECT 55, 1, N'Common.Year', N'Год' UNION ALL
SELECT 56, 1, N'Account.YourPassword', N'Ваш пароль' UNION ALL
SELECT 58, 1, N'Account.Register.Button', N'Зарегистрироваться'
COMMIT;
RAISERROR (N'[dbo].[LocaleStringResource]: Insert Batch: 1.....Done!', 10, 1) WITH NOWAIT;
GO

BEGIN TRANSACTION;
INSERT INTO [dbo].[LocaleStringResource]([Id], [LanguageId], [ResourceName], [ResourceValue])
SELECT 60, 1, N'Account.Fields.ConfirmPassword', N'Подтвердите пароль' UNION ALL
SELECT 61, 1, N'Account.Register.Errors.EmailIsNotProvided', N'Заполните email' UNION ALL
SELECT 62, 1, N'Account.Register.Result.Standard', N'Вы зарегистрированы' UNION ALL
SELECT 63, 1, N'Account.Register.Result.Continue', N'Продолжить' UNION ALL
SELECT 64, 1, N'Account.Register.Errors.PasswordIsNotProvided', N'Введите пароль' UNION ALL
SELECT 65, 1, N'Account.Login.Fields.Email', N'Email' UNION ALL
SELECT 66, 1, N'Account.Login.Fields.Password', N'Пароль' UNION ALL
SELECT 67, 1, N'Account.Login.Fields.RememberMe', N'Запомнить меня' UNION ALL
SELECT 68, 1, N'Account.Login.Fields.Email.Required', N'Заполните поле email' UNION ALL
SELECT 70, 1, N'Account.Login.Welcome', N'Добро пожаловать. Выполните вход или зарегистрируйтесь' UNION ALL
SELECT 71, 1, N'Account.Login.NewCustomer', N'Новый пользователь' UNION ALL
SELECT 72, 1, N'Account.Login.NewCustomerText', N'Создайте аккаунт для того чтобы вы могли приобрести, продать, выставить лот на аукцион. Аккаунт позволит вам совершать покупки гораздо быстрее' UNION ALL
SELECT 73, 1, N'Account.Login.Unsuccessful', N'Не удалось авторизоваться. Исправьте ошибки и попробуйте снова' UNION ALL
SELECT 74, 1, N'Account.Login.ReturningCustomer', N'Есть аккаунт?' UNION ALL
SELECT 75, 1, N'Account.Login.LoginButton', N'Войти' UNION ALL
SELECT 76, 1, N'Account.Login.WrongCredentials.NotRegistered', N'Пользователь не зарегистрирован' UNION ALL
SELECT 77, 1, N'Account.Login.WrongCredentials.UserNotExist', N'Пользователь не существует' UNION ALL
SELECT 78, 1, N'Account.Login.WrongCredentials.Deleted', N'Пользователь удален' UNION ALL
SELECT 79, 1, N'Account.Login.WrongCredentials.NotActive', N'Учетная запись пользователя деактивирована' UNION ALL
SELECT 81, 1, N'Account.Login.WrongCredentials', N'Учетные данные предоставлены неверно' UNION ALL
SELECT 82, 1, N'Account.CustomerInfo', N'Учетные данные' UNION ALL
SELECT 83, 1, N'Media.MagnificPopup.Previous', N'Предыдущее' UNION ALL
SELECT 84, 1, N'Media.MagnificPopup.Next', N'Следующее' UNION ALL
SELECT 87, 1, N'Media.MagnificPopup.Counter', N'%curr% of %total%' UNION ALL
SELECT 88, 1, N'Media.MagnificPopup.Close', N'Закрыть' UNION ALL
SELECT 89, 1, N'Media.MagnificPopup.Loading', N'Загрузка' UNION ALL
SELECT 90, 1, N'EnteredPriceShouldPositive', N'Значение должно быт положительное' UNION ALL
SELECT 91, 1, N'ShoppingCart.EnteredPriceShouldBeMoreThanInitial', N'Значение ставки должно быть выше текущей цены и шага' UNION ALL
SELECT 92, 1, N'Products.BidHasBeenPlaced.Link', N'Ваша ставка была успешно добавлена. Вы можете проследить за своими лотами, ставками в <a href="{0}">кабинете</a>' UNION ALL
SELECT 93, 1, N'Common.Save', N'Сохранить' UNION ALL
SELECT 94, 1, N'Account.AddItem', N'Добавить товар' UNION ALL
SELECT 95, 1, N'Account.MyItems', N'Мои товары' UNION ALL
SELECT 96, 1, N'Account.MyBids', N'Мои ставки' UNION ALL
SELECT 97, 1, N'Account.UserOrders', N'Мои заказы' UNION ALL
SELECT 104, 1, N'Account.WonBids', N'Выигранные лоты' UNION ALL
SELECT 105, 1, N'Account.Navigation', N'Навигация' UNION ALL
SELECT 106, 1, N'account.userinfo', N'Данные' UNION ALL
SELECT 107, 1, N'Admin.Catalog.Products.Fields.Name.Required', N'Пожалуйста, введите название' UNION ALL
SELECT 108, 1, N'Admin.Catalog.Products.Fields.ProductType', N'Тип продажи' UNION ALL
SELECT 110, 1, N'Admin.Catalog.Products.Fields.Name', N'Название' UNION ALL
SELECT 111, 1, N'Admin.Catalog.Products.Fields.ShortDescription', N'Краткое описание' UNION ALL
SELECT 112, 1, N'Admin.Catalog.Products.Fields.FullDescription', N'Полное описание' UNION ALL
SELECT 113, 1, N'Admin.Catalog.Products.Fields.AuctionStartDate', N'Дата начала' UNION ALL
SELECT 114, 1, N'Admin.Catalog.Products.Fields.AuctionEndDate', N'Дата окончания' UNION ALL
SELECT 115, 1, N'Admin.Catalog.Products.Prices', N'Информация о цене' UNION ALL
SELECT 116, 1, N'Admin.Catalog.Products.Mappings', N'Категории' UNION ALL
SELECT 118, 1, N'Admin.Catalog.Products.Fields.Categories.NoCategoriesAvailable', N'Нет доступных категорий' UNION ALL
SELECT 119, 1, N'Admin.Catalog.Products.Fields.Categories', N'Категории' UNION ALL
SELECT 120, 1, N'Admin.Catalog.Products.Fields.Price', N'Цена' UNION ALL
SELECT 121, 1, N'Admin.Catalog.Products.Pictures.Fields.Picture', N'Изображение'
COMMIT;
RAISERROR (N'[dbo].[LocaleStringResource]: Insert Batch: 2.....Done!', 10, 1) WITH NOWAIT;
GO

BEGIN TRANSACTION;
INSERT INTO [dbo].[LocaleStringResource]([Id], [LanguageId], [ResourceName], [ResourceValue])
SELECT 122, 1, N'Admin.Catalog.Products.Pictures.Fields.DisplayOrder', N'Порядок' UNION ALL
SELECT 123, 1, N'Admin.Catalog.Products.Pictures.Fields.OverrideAltAttribute', N'Атрибут Alt' UNION ALL
SELECT 124, 1, N'Admin.Catalog.Products.Pictures.Fields.OverrideTitleAttribute', N'Атрибут Title' UNION ALL
SELECT 125, 1, N'Admin.Common.Delete', N'Удалить' UNION ALL
SELECT 126, 1, N'Admin.Common.Edit', N'Изменить' UNION ALL
SELECT 127, 1, N'Admin.Common.Update', N'Обновить' UNION ALL
SELECT 128, 1, N'Admin.Common.Cancel', N'Отмена' UNION ALL
SELECT 129, 1, N'Admin.Catalog.Products.Pictures.AddButton', N'Добавить' UNION ALL
SELECT 130, 1, N'Admin.Catalog.Products.List.SearchProductName', N'Название товара' UNION ALL
SELECT 131, 1, N'Admin.Catalog.Products.List.SearchCategory', N'Категория' UNION ALL
SELECT 132, 1, N'Admin.Catalog.Products.List.SearchProductType', N'Тип товара' UNION ALL
SELECT 133, 1, N'Admin.Common.DeleteConfirmation', N'Вы уверены что хотите удалить этот товар?'
COMMIT;
RAISERROR (N'[dbo].[LocaleStringResource]: Insert Batch: 3.....Done!', 10, 1) WITH NOWAIT;
GO

SET IDENTITY_INSERT [dbo].[LocaleStringResource] OFF;

