
USE [master]
GO

IF db_id('SteelDaily') IS NULL
  CREATE DATABASE [SteelDaily]
GO

USE [SteelDaily]
GO


DROP TABLE IF EXISTS [UserProfile];
DROP TABLE IF EXISTS Tuning;
DROP TABLE IF EXISTS [Key];
DROP TABLE IF EXISTS Streak;
DROP TABLE IF EXISTS Challenge;
DROP TABLE IF EXISTS [Status];
DROP TABLE IF EXISTS Results;
DROP TABLE IF EXISTS Post;
DROP TABLE IF EXISTS Comment;
DROP TABLE IF EXISTS Game;
DROP TABLE IF EXISTS Scale;

CREATE TABLE [UserProfile] (
  [Id] integer PRIMARY KEY IDENTITY,
  [Username] nvarchar(255),
  [FirstName] nvarchar(50) NOT NULL,
  [LastName] nvarchar(50) NOT NULL,
  [Email] nvarchar(555) NOT NULL,
  [FirebaseUserId] NVARCHAR(28) NOT NULL,
  [CreateDateTime] datetime NOT NULL,
  [ImageLocation] nvarchar(255),
  [Description] nvarchar(255),

  CONSTRAINT UQ_FirebaseUserId UNIQUE(FirebaseUserId),
  CONSTRAINT UQ_Email UNIQUE(Email)
)

CREATE TABLE [Tuning] (
  [Id] int PRIMARY KEY IDENTITY,
  [Name] nvarchar(255),
  [Notes] nvarchar(255)
)
GO

CREATE TABLE [Key] (
  [Id] int PRIMARY KEY IDENTITY,
  [Root] nvarchar(255)
)
GO

CREATE TABLE Streak (
  [Id] int PRIMARY KEY IDENTITY,
  [Days] int,
  [UserProfileId] int,
  [DateBegun] date,
  [LastUpdate] date,

	CONSTRAINT [FK_Streak_UserProfile] FOREIGN KEY ([UserProfileId])
	REFERENCES [UserProfile] ([Id])
)
GO

CREATE TABLE Challenge (
  [Id] int PRIMARY KEY IDENTITY,
  [StatusId] int,
  [UserProfileOneId] int,
  [UserProfileTwoId] int

  CONSTRAINT [FK_Challenge_Status] FOREIGN KEY ([StatusId])
	REFERENCES [Status] ([Id]),
	  /*CONSTRAINT [FK_Challenge_UserProfile] FOREIGN KEY (UserProfileOneId])
	REFERENCES [UserProfile] ([Id]),*/
)
GO

CREATE TABLE [Status] (
  [Id] int PRIMARY KEY IDENTITY,
  [Name] nvarchar(255)
)
GO

CREATE TABLE Results (
  [Id] int PRIMARY KEY IDENTITY,
  [UserProfileId] int,
  [GameId] int,
  [Key] nvarchar(5),
  [ScaleId] int,
  [TuningId] int,
  [Questions] nvarchar,
  [Answers] nvarchar,
  [Public] bit,
  [Date] date,
  [Complete] bit

  	CONSTRAINT [FK_Results_UserProfile] FOREIGN KEY ([UserProfileId])
		REFERENCES [UserProfile] ([Id]),
	CONSTRAINT [FK_Results_Scale] FOREIGN KEY ([ScaleId])
		REFERENCES [Scale] ([Id]),
	CONSTRAINT [FK_Results_Tuning] FOREIGN KEY ([TuningId])
		REFERENCES [Tuning] ([Id])
)
GO

CREATE TABLE Post (
  [Id] int PRIMARY KEY IDENTITY,
  [UserProfileId] int,
  [Title] nvarchar(255),
  [Content] nvarchar(255),
  [ResultId] int,

    CONSTRAINT [FK_Post_UserProfile] FOREIGN KEY ([UserProfileId])
		REFERENCES [UserProfile] ([Id]),

	CONSTRAINT [FK_Post_Result] FOREIGN KEY ([ResultId])
		REFERENCES [Result] ([Id])
)
GO

CREATE TABLE Comment (
  [Id] int PRIMARY KEY IDENTITY,
  [UserProfileId] int,
  [PostId] int,
    CONSTRAINT [FK_Comment_UserProfile] FOREIGN KEY ([UserProfileId])
	REFERENCES [UserProfile] ([Id])

)
GO

CREATE TABLE Game (
  [Id] int PRIMARY KEY IDENTITY,
  [Name] nvarchar(255)
)
GO

CREATE TABLE Scale (
  [Id] int PRIMARY KEY IDENTITY,
  [Name] nvarchar(255),
  [Pattern] nvarchar(255)
)
GO

