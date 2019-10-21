		
SET NUMERIC_ROUNDABORT OFF
GO
SET ANSI_PADDING, ANSI_WARNINGS, CONCAT_NULL_YIELDS_NULL, ARITHABORT, QUOTED_IDENTIFIER, ANSI_NULLS, NOCOUNT ON
GO
SET DATEFORMAT YMD
GO
SET XACT_ABORT ON
GO
SET TRANSACTION ISOLATION LEVEL Serializable
GO
BEGIN TRANSACTION

PRINT(N'Drop constraint FK_PersonToPerson_RelationTypes from [dbo].[PersonToPerson]')
ALTER TABLE [dbo].[PersonToPerson] NOCHECK CONSTRAINT [FK_PersonToPerson_RelationTypes]

PRINT(N'Drop constraint FK_Person_Gender from [dbo].[Person]')
ALTER TABLE [dbo].[Person] NOCHECK CONSTRAINT [FK_Person_Gender]

PRINT(N'Drop constraint FK_Person_City from [dbo].[Person]')
ALTER TABLE [dbo].[Person] NOCHECK CONSTRAINT [FK_Person_City]

PRINT(N'Add 3 rows to [dbo].[City]')
SET IDENTITY_INSERT [dbo].[City] ON
INSERT INTO [dbo].[City] ([ID], [Name]) VALUES (1, N'თბილისი')
INSERT INTO [dbo].[City] ([ID], [Name]) VALUES (2, N'ქუთაისი')
INSERT INTO [dbo].[City] ([ID], [Name]) VALUES (3, N'ბათუმი')
SET IDENTITY_INSERT [dbo].[City] OFF

PRINT(N'Add 2 rows to [dbo].[Gender]')
SET IDENTITY_INSERT [dbo].[Gender] ON
INSERT INTO [dbo].[Gender] ([ID], [Name]) VALUES (1, N'female')
INSERT INTO [dbo].[Gender] ([ID], [Name]) VALUES (2, N'male')
SET IDENTITY_INSERT [dbo].[Gender] OFF

PRINT(N'Add 4 rows to [dbo].[RelationTypes]')
SET IDENTITY_INSERT [dbo].[RelationTypes] ON
INSERT INTO [dbo].[RelationTypes] ([ID], [Name]) VALUES (1, N'კოლეგა')
INSERT INTO [dbo].[RelationTypes] ([ID], [Name]) VALUES (2, N'ნაცნობი')
INSERT INTO [dbo].[RelationTypes] ([ID], [Name]) VALUES (3, N'ნათესავი')
INSERT INTO [dbo].[RelationTypes] ([ID], [Name]) VALUES (4, N'სხვა')
SET IDENTITY_INSERT [dbo].[RelationTypes] OFF
ALTER TABLE [dbo].[PersonToPerson] WITH CHECK CHECK CONSTRAINT [FK_PersonToPerson_RelationTypes]
ALTER TABLE [dbo].[Person] WITH CHECK CHECK CONSTRAINT [FK_Person_Gender]
ALTER TABLE [dbo].[Person] WITH CHECK CHECK CONSTRAINT [FK_Person_City]
COMMIT TRANSACTION
GO
