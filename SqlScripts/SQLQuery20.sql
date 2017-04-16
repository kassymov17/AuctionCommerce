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
SELECT 20, 1, N'Media.Category.ImageAlternateTextFormat', N'Изображение категории {0}'
COMMIT;
RAISERROR (N'[dbo].[LocaleStringResource]: Insert Batch: 1.....Done!', 10, 1) WITH NOWAIT;
GO

SET IDENTITY_INSERT [dbo].[LocaleStringResource] OFF;

