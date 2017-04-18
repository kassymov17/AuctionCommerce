USE [AuctionCommerce];
SET NOCOUNT ON;
SET XACT_ABORT ON;
GO

SET IDENTITY_INSERT [dbo].[Item] ON;

BEGIN TRANSACTION;
INSERT INTO [dbo].[Item]([Id], [Name], [ShortDescription], [FullDescription], [ShowOnHomePage], [MetaKeywords], [MetaTitle], [MetaDescription], [ApprovedRatingSum], [NotApprovedRatingSum], [ApprovedTotalReviews], [NotApprovedTotalReviews], [StockQuantity], [DisplayStockAvailability], [DisplayStockQuantity], [DisableBuyButton], [DisableWishlistButton], [InitialPrice], [BidStep], [AuctionStartDate], [AuctionEndDate], [MarkAsNew], [MarkAsNewStartDateTimeUtc], [MarkAsNewEndDateTimeUtc], [Weight], [Length], [Width], [Height], [Published], [Deleted], [CreatedOnUtc], [UpdatedOnUtc], [ItemType], [UserId])
SELECT 4, N'Apple MacBook Pro 13-inch', N'A groundbreaking Retina display. A new force-sensing trackpad. All-flash architecture. Powerful dual-core and quad-core Intel processors. Together, these features take the notebook to a new level of performance. And they will do the same for you in everything you create.', N'<p>With fifth-generation Intel Core processors, the latest graphics, and faster flash storage, the incredibly advanced MacBook Pro with Retina display moves even further ahead in performance and battery life.* *Compared with the previous generation.</p><p>Retina display with 2560-by-1600 resolution</p><p>Fifth-generation dual-core Intel Core i5 processor</p><p>Intel Iris Graphics</p><p>Up to 9 hours of battery life1</p><p>Faster flash storage2</p><p>802.11ac Wi-Fi</p><p>Two Thunderbolt 2 ports for connecting high-performance devices and transferring data at lightning speed</p><p>Two USB 3 ports (compatible with USB 2 devices) and HDMI</p><p>FaceTime HD camera</p><p>Pages, Numbers, Keynote, iPhoto, iMovie, GarageBand included</p><p>OS X, the world''s most advanced desktop operating system</p>', 1, NULL, NULL, NULL, 0, 0, 0, 0, 200, 1, 1, 0, 0, 250000.0000, 0.0000, NULL, NULL, 0, NULL, NULL, 3.0000, 3.0000, 3.0000, 3.0000, 1, 0, '20170201 19:31:40.207', '20170201 19:31:40.207', 1, 1 UNION ALL
SELECT 10, N'HP Spectre XT Pro UltraBook', N'HP Spectre XT Pro UltraBook / Intel Core i5-2467M / 13.3 / 4GB / 128GB / Windows 7 Professional / Laptop', N'<p>Introducing HP ENVY Spectre XT, the Ultrabook designed for those who want style without sacrificing substance. It''s sleek. It''s thin. And with Intel. Corer i5 processor and premium materials, it''s designed to go anywhere from the bistro to the boardroom, it''s unlike anything you''ve ever seen from HP.</p>', 1, NULL, NULL, NULL, 0, 0, 0, 0, 300, 1, 1, 1, 0, 50000.0000, 5000.0000, '20170414 00:00:00.000', '20170417 00:00:00.000', 0, NULL, NULL, 3.0000, 2.0000, 1.0000, 1.0000, 1, 0, '20170414 00:00:00.000', '20170414 00:00:00.000', 2, 1
COMMIT;
RAISERROR (N'[dbo].[Item]: Insert Batch: 1.....Done!', 10, 1) WITH NOWAIT;
GO

SET IDENTITY_INSERT [dbo].[Item] OFF;

