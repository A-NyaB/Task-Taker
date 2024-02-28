USE [master]

IF db_id('TaskTaker') IS NULL
  CREATE DATABASE [TaskTaker]
GO

USE [TaskTaker]
GO

DROP TABLE IF EXISTS [Comment];
DROP TABLE IF EXISTS [Task];
DROP TABLE IF EXISTS [TaskList];
DROP TABLE IF EXISTS [Subscription];
DROP TABLE IF EXISTS [UserProfile];
DROP TABLE IF EXISTS [Status];
GO

CREATE TABLE [Status] (
[Id] INT PRIMARY KEY IDENTITY,
[Progress] VARCHAR(50),
);

CREATE TABLE [UserProfile] (
  [Id] INT PRIMARY KEY IDENTITY,
  [DisplayName] VARCHAR(50),
  [FirstName] VARCHAR(50),
  [LastName] VARCHAR(50),
  [Email] VARCHAR(555),
  [CreateDateTime] DATETIME,
  [ImageLocation] VARCHAR(255)
);

CREATE TABLE [Subscription] (
  [Id] INT PRIMARY KEY IDENTITY,
  [SubscriberUserProfileId] INT,
  [ProviderUserProfileId] INT,
  CONSTRAINT [FK_Subscription_SubscriberUserProfileId] FOREIGN KEY ([SubscriberUserProfileId]) REFERENCES [UserProfile] ([Id]),
  CONSTRAINT [FK_Subscription_ProviderUserProfileId] FOREIGN KEY ([ProviderUserProfileId]) REFERENCES [UserProfile] ([Id])
);

CREATE TABLE [TaskList] (
  [Id] INT PRIMARY KEY IDENTITY,
  [UserId] INT,
  [ListTitle] VARCHAR(255),
  CONSTRAINT [FK_TaskList_UserProfile_UserId] FOREIGN KEY ([UserId]) REFERENCES [UserProfile] ([Id])
);

CREATE TABLE [Task] (
  [Id] INT PRIMARY KEY IDENTITY,
  [TaskListId] INT,
  [Title] VARCHAR(255),
  [Description] TEXT,
  [StatusId] INT,
  [EstimatedTime] INT,
  [ActualTime] INT,
  [Completed] BIT,
  CONSTRAINT [FK_Task_TaskList_TaskListId] FOREIGN KEY ([TaskListId]) REFERENCES [TaskList] ([Id]),
  CONSTRAINT [FK_Task_Status_StatusId] FOREIGN KEY ([StatusId]) REFERENCES [Status] ([Id]),
);


CREATE TABLE [Comment] (
  [Id] INT PRIMARY KEY IDENTITY,
  [TaskId] INT,
  [UserId] INT,
  [Content] TEXT,
  [Timestamp] DATETIME,
  CONSTRAINT [FK_Comment_Task_TaskId] FOREIGN KEY ([TaskId]) REFERENCES [Task] ([Id]),
  CONSTRAINT [FK_Comment_UserProfile_UserId ] FOREIGN KEY ([UserId]) REFERENCES [UserProfile] ([Id])
);
GO
