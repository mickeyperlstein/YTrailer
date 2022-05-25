
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 07/12/2015 19:38:52
-- Generated from EDMX file: U:\Dropbox\Dropbox\dev_projects\YTrailer\YtrailerWeb\Models\Model1.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [YTrailerWeb.Models.MyDBContext];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[YTasks]', 'U') IS NOT NULL
    DROP TABLE [dbo].[YTasks];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'YTasks'
CREATE TABLE [dbo].[YTasks] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [YouTubeUrl] nvarchar(max)  NULL,
    [State] int  NOT NULL,
    [StartDate] datetime  NULL,
    [EndTime] datetime  NULL,
    [isHandled] bit  NOT NULL
);
GO

-- Creating table 'YTitles'
CREATE TABLE [dbo].[YTitles] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Title] nvarchar(max)  NOT NULL,
    [Description] nvarchar(max)  NOT NULL,
    [Author] nvarchar(max)  NOT NULL,
    [YTask_Id] int  NOT NULL
);
GO

-- Creating table 'PromoRequests'
CREATE TABLE [dbo].[PromoRequests] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Title1] nvarchar(max)  NOT NULL,
    [Title2] nvarchar(max)  NOT NULL,
    [Title3] nvarchar(max)  NOT NULL,
    [Title4] nvarchar(max)  NOT NULL,
    [BgMusicFile] nvarchar(max)  NOT NULL,
    [Seconds] float  NOT NULL,
    [YTask_Id] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'YTasks'
ALTER TABLE [dbo].[YTasks]
ADD CONSTRAINT [PK_YTasks]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'YTitles'
ALTER TABLE [dbo].[YTitles]
ADD CONSTRAINT [PK_YTitles]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'PromoRequests'
ALTER TABLE [dbo].[PromoRequests]
ADD CONSTRAINT [PK_PromoRequests]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [YTask_Id] in table 'YTitles'
ALTER TABLE [dbo].[YTitles]
ADD CONSTRAINT [FK_YTitleYTask]
    FOREIGN KEY ([YTask_Id])
    REFERENCES [dbo].[YTasks]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_YTitleYTask'
CREATE INDEX [IX_FK_YTitleYTask]
ON [dbo].[YTitles]
    ([YTask_Id]);
GO

-- Creating foreign key on [YTask_Id] in table 'PromoRequests'
ALTER TABLE [dbo].[PromoRequests]
ADD CONSTRAINT [FK_PromoRequestYTask]
    FOREIGN KEY ([YTask_Id])
    REFERENCES [dbo].[YTasks]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_PromoRequestYTask'
CREATE INDEX [IX_FK_PromoRequestYTask]
ON [dbo].[PromoRequests]
    ([YTask_Id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------