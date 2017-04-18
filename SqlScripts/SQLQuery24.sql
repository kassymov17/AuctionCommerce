USE [AuctionCommerce];
SET NOCOUNT ON;
SET XACT_ABORT ON;
GO

SET IDENTITY_INSERT [dbo].[UserRole] ON;

BEGIN TRANSACTION;
INSERT INTO [dbo].[UserRole]([Id], [Name], [Active], [IsSystemRole], [SystemName])
SELECT 1, N'Guests', 1, 1, N'Guests' UNION ALL
SELECT 2, N'Registered', 1, 1, N'Registered'
COMMIT;
RAISERROR (N'[dbo].[UserRole]: Insert Batch: 1.....Done!', 10, 1) WITH NOWAIT;
GO

SET IDENTITY_INSERT [dbo].[UserRole] OFF;

