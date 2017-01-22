CREATE TABLE [dbo].[Venue] (
    [Id]          INT           IDENTITY (1, 1) NOT NULL,
    [Name]        VARCHAR (20)  NOT NULL,
    [Description] VARCHAR (MAX) NULL,
    CONSTRAINT [PK_Venue] PRIMARY KEY CLUSTERED ([Id] ASC)
);

