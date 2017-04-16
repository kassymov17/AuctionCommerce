USE [AuctionCommerce];
SET NOCOUNT ON;
SET XACT_ABORT ON;
GO

SET IDENTITY_INSERT [dbo].[Topic] ON;

BEGIN TRANSACTION;
INSERT INTO [dbo].[Topic]([Id], [SystemName], [DisplayOrder], [Title], [Body], [Published], [MetaKeywords], [MetaDescription], [MetaTitle], [IncludedInTopMenu], [IncludeInFooterColumn1], [IncludeInFooterColumn2], [IncludeInFooterColumn3])
SELECT 3, N'HomePageText', 1, N'����� ����������!', N'<p>������ ���� �������� ������-��������� � ���������. ����� �� ������ ���������� ����������� ������ � ������� ���� ����.</p><p> ���� � ��� �������� �������, �� ������ �������� ��� <a href="http://localhost:62941/contactus">�� �����</a></p>', 1, NULL, NULL, NULL, 0, 0, 0, 0
COMMIT;
RAISERROR (N'[dbo].[Topic]: Insert Batch: 1.....Done!', 10, 1) WITH NOWAIT;
GO

SET IDENTITY_INSERT [dbo].[Topic] OFF;

