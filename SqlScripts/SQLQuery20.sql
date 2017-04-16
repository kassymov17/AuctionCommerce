USE [AuctionCommerce];
SET NOCOUNT ON;
SET XACT_ABORT ON;
GO

SET IDENTITY_INSERT [dbo].[LocaleStringResource] ON;

BEGIN TRANSACTION;
INSERT INTO [dbo].[LocaleStringResource]([Id], [LanguageId], [ResourceName], [ResourceValue])
SELECT 1, 1, N'Footer.Information', N'����������' UNION ALL
SELECT 2, 1, N'ContactUs', N'�������� ���' UNION ALL
SELECT 3, 1, N'Footer.UserService', N'���������' UNION ALL
SELECT 4, 1, N'Search', N'�����' UNION ALL
SELECT 5, 1, N'News', N'�������' UNION ALL
SELECT 6, 1, N'Products.RecentlyViewedProducts', N'������������� ������' UNION ALL
SELECT 7, 1, N'Products.NewProducts', N'�������' UNION ALL
SELECT 8, 1, N'Footer.MyAccount', N'��� �������' UNION ALL
SELECT 9, 1, N'Account.MyAccount', N'��� �������' UNION ALL
SELECT 10, 1, N'Account.UserOrders', N'��� ������' UNION ALL
SELECT 11, 1, N'ShoppingCart', N'�������' UNION ALL
SELECT 12, 1, N'Wishlist', N'���������' UNION ALL
SELECT 14, 1, N'Categories', N'���������' UNION ALL
SELECT 17, 1, N'Menu', N'����' UNION ALL
SELECT 18, 1, N'Media.Category.ImageLinkTitleFormat', N'�������� ������ � ��������� {0}' UNION ALL
SELECT 20, 1, N'Media.Category.ImageAlternateTextFormat', N'����������� ��������� {0}'
COMMIT;
RAISERROR (N'[dbo].[LocaleStringResource]: Insert Batch: 1.....Done!', 10, 1) WITH NOWAIT;
GO

SET IDENTITY_INSERT [dbo].[LocaleStringResource] OFF;

