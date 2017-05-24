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
SELECT 20, 1, N'Media.Category.ImageAlternateTextFormat', N'����������� ��������� {0}' UNION ALL
SELECT 21, 1, N'HomePage.Products', N'��������� ������' UNION ALL
SELECT 23, 1, N'ShoppingCart.AddToCart', N'� �������' UNION ALL
SELECT 25, 1, N'ShoppingCart.AddToWishlist', N'� ���������' UNION ALL
SELECT 26, 1, N'Auction.GoToDetails', N'���������' UNION ALL
SELECT 28, 1, N'ShoppingCart.HeaderQuantity', N'({0})' UNION ALL
SELECT 29, 1, N'Products.ProductHasBeenAddedToTheCart.Link', N'����� ��� �������� � <a href="{0}">�������</a>' UNION ALL
SELECT 30, 1, N'Common.Notification', N'�����������' UNION ALL
SELECT 31, 1, N'Common.Error', N'������' UNION ALL
SELECT 32, 1, N'Common.Close', N'�������' UNION ALL
SELECT 33, 1, N'Account.Fields.Email', N'Email' UNION ALL
SELECT 34, 1, N'Account.Fields.Username', N'�����' UNION ALL
SELECT 35, 1, N'Account.Fields.Password', N'������' UNION ALL
SELECT 36, 1, N'Account.Fields.Gender', N'���' UNION ALL
SELECT 37, 1, N'Account.Fields.FirstName', N'���' UNION ALL
SELECT 38, 1, N'Account.Fields.LastName', N'�������' UNION ALL
SELECT 39, 1, N'Account.Fields.DateOfBirth', N'���� ��������' UNION ALL
SELECT 40, 1, N'Account.Fields.StreetAddress', N'�����' UNION ALL
SELECT 41, 1, N'Account.Fields.City', N'�����' UNION ALL
SELECT 42, 1, N'Account.Fields.Phone', N'�������' UNION ALL
SELECT 43, 1, N'Account.Fields.Email.Required', N'Email ������������ ����' UNION ALL
SELECT 44, 1, N'Common.WrongEmail', N'�������� email' UNION ALL
SELECT 45, 1, N'Account.Fields.Username.Required', N'����� ������������ ����' UNION ALL
SELECT 46, 1, N'Account.Fields.FirstName.Required', N'������� ���' UNION ALL
SELECT 47, 1, N'Account.Fields.LastName.Required', N'������� �������' UNION ALL
SELECT 48, 1, N'HomePage', N'�������' UNION ALL
SELECT 49, 1, N'Account.Register', N'�����������' UNION ALL
SELECT 50, 1, N'Account.YourPersonalDetails', N'������������ ������' UNION ALL
SELECT 51, 1, N'Account.Fields.Gender.Male', N'�������' UNION ALL
SELECT 52, 1, N'Account.Fields.Gender.Female', N'�������' UNION ALL
SELECT 53, 1, N'Common.Day', N'����' UNION ALL
SELECT 54, 1, N'Common.Month', N'�����' UNION ALL
SELECT 55, 1, N'Common.Year', N'���' UNION ALL
SELECT 56, 1, N'Account.YourPassword', N'��� ������' UNION ALL
SELECT 58, 1, N'Account.Register.Button', N'������������������'
COMMIT;
RAISERROR (N'[dbo].[LocaleStringResource]: Insert Batch: 1.....Done!', 10, 1) WITH NOWAIT;
GO

BEGIN TRANSACTION;
INSERT INTO [dbo].[LocaleStringResource]([Id], [LanguageId], [ResourceName], [ResourceValue])
SELECT 60, 1, N'Account.Fields.ConfirmPassword', N'����������� ������' UNION ALL
SELECT 61, 1, N'Account.Register.Errors.EmailIsNotProvided', N'��������� email' UNION ALL
SELECT 62, 1, N'Account.Register.Result.Standard', N'�� ����������������' UNION ALL
SELECT 63, 1, N'Account.Register.Result.Continue', N'����������' UNION ALL
SELECT 64, 1, N'Account.Register.Errors.PasswordIsNotProvided', N'������� ������' UNION ALL
SELECT 65, 1, N'Account.Login.Fields.Email', N'Email' UNION ALL
SELECT 66, 1, N'Account.Login.Fields.Password', N'������' UNION ALL
SELECT 67, 1, N'Account.Login.Fields.RememberMe', N'��������� ����' UNION ALL
SELECT 68, 1, N'Account.Login.Fields.Email.Required', N'��������� ���� email' UNION ALL
SELECT 70, 1, N'Account.Login.Welcome', N'����� ����������. ��������� ���� ��� �����������������' UNION ALL
SELECT 71, 1, N'Account.Login.NewCustomer', N'����� ������������' UNION ALL
SELECT 72, 1, N'Account.Login.NewCustomerText', N'�������� ������� ��� ���� ����� �� ����� ����������, �������, ��������� ��� �� �������. ������� �������� ��� ��������� ������� ������� �������' UNION ALL
SELECT 73, 1, N'Account.Login.Unsuccessful', N'�� ������� ��������������. ��������� ������ � ���������� �����' UNION ALL
SELECT 74, 1, N'Account.Login.ReturningCustomer', N'���� �������?' UNION ALL
SELECT 75, 1, N'Account.Login.LoginButton', N'�����' UNION ALL
SELECT 76, 1, N'Account.Login.WrongCredentials.NotRegistered', N'������������ �� ���������������' UNION ALL
SELECT 77, 1, N'Account.Login.WrongCredentials.UserNotExist', N'������������ �� ����������' UNION ALL
SELECT 78, 1, N'Account.Login.WrongCredentials.Deleted', N'������������ ������' UNION ALL
SELECT 79, 1, N'Account.Login.WrongCredentials.NotActive', N'������� ������ ������������ ��������������' UNION ALL
SELECT 81, 1, N'Account.Login.WrongCredentials', N'������� ������ ������������� �������' UNION ALL
SELECT 82, 1, N'Account.CustomerInfo', N'������� ������' UNION ALL
SELECT 83, 1, N'Media.MagnificPopup.Previous', N'����������' UNION ALL
SELECT 84, 1, N'Media.MagnificPopup.Next', N'���������' UNION ALL
SELECT 87, 1, N'Media.MagnificPopup.Counter', N'%curr% of %total%' UNION ALL
SELECT 88, 1, N'Media.MagnificPopup.Close', N'�������' UNION ALL
SELECT 89, 1, N'Media.MagnificPopup.Loading', N'��������' UNION ALL
SELECT 90, 1, N'EnteredPriceShouldPositive', N'�������� ������ ��� �������������' UNION ALL
SELECT 91, 1, N'ShoppingCart.EnteredPriceShouldBeMoreThanInitial', N'�������� ������ ������ ���� ���� �������� ����' UNION ALL
SELECT 92, 1, N'Products.BidHasBeenPlaced.Link', N'���� ������ ���� ������� ���������. �� ������ ���������� �� ������ ������, �������� � <a href="{0}">��������</a>' UNION ALL
SELECT 93, 1, N'Common.Save', N'���������' UNION ALL
SELECT 94, 1, N'Account.AddItem', N'�������� �����' UNION ALL
SELECT 95, 1, N'Account.MyItems', N'��� ������' UNION ALL
SELECT 96, 1, N'Account.MyBids', N'��� ������' UNION ALL
SELECT 97, 1, N'Account.UserOrders', N'��� ������' UNION ALL
SELECT 104, 1, N'Account.WonBids', N'���������� ����' UNION ALL
SELECT 105, 1, N'Account.Navigation', N'���������' UNION ALL
SELECT 106, 1, N'account.userinfo', N'������' UNION ALL
SELECT 107, 1, N'Admin.Catalog.Products.Fields.Name.Required', N'����������, ������� ��������' UNION ALL
SELECT 108, 1, N'Admin.Catalog.Products.Fields.ProductType', N'��� �������' UNION ALL
SELECT 110, 1, N'Admin.Catalog.Products.Fields.Name', N'��������' UNION ALL
SELECT 111, 1, N'Admin.Catalog.Products.Fields.ShortDescription', N'������� ��������' UNION ALL
SELECT 112, 1, N'Admin.Catalog.Products.Fields.FullDescription', N'������ ��������' UNION ALL
SELECT 113, 1, N'Admin.Catalog.Products.Fields.AuctionStartDate', N'���� ������' UNION ALL
SELECT 114, 1, N'Admin.Catalog.Products.Fields.AuctionEndDate', N'���� ���������' UNION ALL
SELECT 115, 1, N'Admin.Catalog.Products.Prices', N'���������� � ����' UNION ALL
SELECT 116, 1, N'Admin.Catalog.Products.Mappings', N'���������' UNION ALL
SELECT 118, 1, N'Admin.Catalog.Products.Fields.Categories.NoCategoriesAvailable', N'��� ��������� ���������' UNION ALL
SELECT 119, 1, N'Admin.Catalog.Products.Fields.Categories', N'���������' UNION ALL
SELECT 120, 1, N'Admin.Catalog.Products.Fields.Price', N'����' UNION ALL
SELECT 121, 1, N'Admin.Catalog.Products.Pictures.Fields.Picture', N'�����������'
COMMIT;
RAISERROR (N'[dbo].[LocaleStringResource]: Insert Batch: 2.....Done!', 10, 1) WITH NOWAIT;
GO

BEGIN TRANSACTION;
INSERT INTO [dbo].[LocaleStringResource]([Id], [LanguageId], [ResourceName], [ResourceValue])
SELECT 122, 1, N'Admin.Catalog.Products.Pictures.Fields.DisplayOrder', N'�������' UNION ALL
SELECT 123, 1, N'Admin.Catalog.Products.Pictures.Fields.OverrideAltAttribute', N'������� Alt' UNION ALL
SELECT 124, 1, N'Admin.Catalog.Products.Pictures.Fields.OverrideTitleAttribute', N'������� Title' UNION ALL
SELECT 125, 1, N'Admin.Common.Delete', N'�������' UNION ALL
SELECT 126, 1, N'Admin.Common.Edit', N'��������' UNION ALL
SELECT 127, 1, N'Admin.Common.Update', N'��������' UNION ALL
SELECT 128, 1, N'Admin.Common.Cancel', N'������' UNION ALL
SELECT 129, 1, N'Admin.Catalog.Products.Pictures.AddButton', N'��������'
COMMIT;
RAISERROR (N'[dbo].[LocaleStringResource]: Insert Batch: 3.....Done!', 10, 1) WITH NOWAIT;
GO

SET IDENTITY_INSERT [dbo].[LocaleStringResource] OFF;

