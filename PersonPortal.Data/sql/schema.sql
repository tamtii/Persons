
SET NUMERIC_ROUNDABORT OFF
GO
SET ANSI_PADDING, ANSI_WARNINGS, CONCAT_NULL_YIELDS_NULL, ARITHABORT, QUOTED_IDENTIFIER, ANSI_NULLS ON
GO
SET XACT_ABORT ON
GO
SET TRANSACTION ISOLATION LEVEL Serializable
GO
BEGIN TRANSACTION
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating [dbo].[City]'
GO
CREATE TABLE [dbo].[City]
(
[ID] [int] NOT NULL IDENTITY(1, 1),
[Name] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL
)
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating primary key [PK_City] on [dbo].[City]'
GO
ALTER TABLE [dbo].[City] ADD CONSTRAINT [PK_City] PRIMARY KEY CLUSTERED  ([ID])
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating [dbo].[Person]'
GO
CREATE TABLE [dbo].[Person]
(
[ID] [int] NOT NULL IDENTITY(1, 1),
[FirstName] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[LastName] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[GenderiD] [int] NOT NULL,
[PersonalNumber] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[BirthDate] [date] NOT NULL,
[CityID] [int] NULL,
[ImagePath] [nvarchar] (max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[IsDeleted] [bit] NOT NULL
)
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating primary key [PK_Person] on [dbo].[Person]'
GO
ALTER TABLE [dbo].[Person] ADD CONSTRAINT [PK_Person] PRIMARY KEY CLUSTERED  ([ID])
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating [dbo].[Gender]'
GO
CREATE TABLE [dbo].[Gender]
(
[ID] [int] NOT NULL IDENTITY(1, 1),
[Name] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL
)
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating primary key [PK_Gender] on [dbo].[Gender]'
GO
ALTER TABLE [dbo].[Gender] ADD CONSTRAINT [PK_Gender] PRIMARY KEY CLUSTERED  ([ID])
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating [dbo].[PersonPhone]'
GO
CREATE TABLE [dbo].[PersonPhone]
(
[ID] [int] NOT NULL IDENTITY(1, 1),
[PersonID] [int] NULL,
[PhoneTypeID] [int] NULL,
[PhoneNumber] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[IsDeleted] [bit] NULL
)
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating primary key [PK_PersonPhone] on [dbo].[PersonPhone]'
GO
ALTER TABLE [dbo].[PersonPhone] ADD CONSTRAINT [PK_PersonPhone] PRIMARY KEY CLUSTERED  ([ID])
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating [dbo].[PhoneType]'
GO
CREATE TABLE [dbo].[PhoneType]
(
[ID] [int] NOT NULL IDENTITY(1, 1),
[Name] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL
)
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating primary key [PK_PhoneType] on [dbo].[PhoneType]'
GO
ALTER TABLE [dbo].[PhoneType] ADD CONSTRAINT [PK_PhoneType] PRIMARY KEY CLUSTERED  ([ID])
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating [dbo].[PersonToPerson]'
GO
CREATE TABLE [dbo].[PersonToPerson]
(
[ID] [int] NOT NULL IDENTITY(1, 1),
[PersonID] [int] NULL,
[RelatedPersonID] [int] NULL,
[RelationTypeID] [int] NULL
)
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating primary key [PK_PersonToPerson] on [dbo].[PersonToPerson]'
GO
ALTER TABLE [dbo].[PersonToPerson] ADD CONSTRAINT [PK_PersonToPerson] PRIMARY KEY CLUSTERED  ([ID])
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating [dbo].[RelationTypes]'
GO
CREATE TABLE [dbo].[RelationTypes]
(
[ID] [int] NOT NULL IDENTITY(1, 1),
[Name] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL
)
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating primary key [PK_RelationTypes] on [dbo].[RelationTypes]'
GO
ALTER TABLE [dbo].[RelationTypes] ADD CONSTRAINT [PK_RelationTypes] PRIMARY KEY CLUSTERED  ([ID])
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Adding foreign keys to [dbo].[Person]'
GO
ALTER TABLE [dbo].[Person] ADD CONSTRAINT [FK_Person_City] FOREIGN KEY ([CityID]) REFERENCES [dbo].[City] ([ID])
GO
ALTER TABLE [dbo].[Person] ADD CONSTRAINT [FK_Person_Gender] FOREIGN KEY ([GenderiD]) REFERENCES [dbo].[Gender] ([ID])
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Adding foreign keys to [dbo].[PersonPhone]'
GO
ALTER TABLE [dbo].[PersonPhone] ADD CONSTRAINT [FK_PersonPhone_Person] FOREIGN KEY ([PersonID]) REFERENCES [dbo].[Person] ([ID])
GO
ALTER TABLE [dbo].[PersonPhone] ADD CONSTRAINT [FK_PersonPhone_PhoneType] FOREIGN KEY ([PhoneTypeID]) REFERENCES [dbo].[PhoneType] ([ID])
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Adding foreign keys to [dbo].[PersonToPerson]'
GO
ALTER TABLE [dbo].[PersonToPerson] ADD CONSTRAINT [FK_PersonToPerson_Person] FOREIGN KEY ([PersonID]) REFERENCES [dbo].[Person] ([ID])
GO
ALTER TABLE [dbo].[PersonToPerson] ADD CONSTRAINT [FK_PersonToPerson_Person1] FOREIGN KEY ([RelatedPersonID]) REFERENCES [dbo].[Person] ([ID])
GO
ALTER TABLE [dbo].[PersonToPerson] ADD CONSTRAINT [FK_PersonToPerson_RelationTypes] FOREIGN KEY ([RelationTypeID]) REFERENCES [dbo].[RelationTypes] ([ID])
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
COMMIT TRANSACTION
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
IF HAS_PERMS_BY_NAME(N'sys.xp_logevent', N'OBJECT', N'EXECUTE') = 1
BEGIN
    DECLARE @databaseName AS nvarchar(2048), @eventMessage AS nvarchar(2048)
    SET @databaseName = REPLACE(REPLACE(DB_NAME(), N'\', N'\\'), N'"', N'\"')
    SET @eventMessage = N'Redgate SQL Compare: { "deployment": { "description": "Redgate SQL Compare deployed to ' + @databaseName + N'", "database": "' + @databaseName + N'" }}'
    EXECUTE sys.xp_logevent 55000, @eventMessage
END
GO
DECLARE @Success AS BIT
SET @Success = 1
SET NOEXEC OFF
IF (@Success = 1) PRINT 'The database update succeeded'
ELSE BEGIN
	IF @@TRANCOUNT > 0 ROLLBACK TRANSACTION
	PRINT 'The database update failed'
END
GO
