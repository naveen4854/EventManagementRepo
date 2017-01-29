CREATE TABLE [dbo].[Title] (
    [Id]   INT           IDENTITY (1, 1) NOT NULL,
    [Name] VARCHAR (100) NOT NULL,
    CONSTRAINT [PK_Title] PRIMARY KEY CLUSTERED ([Id] ASC)
);

