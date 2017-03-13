CREATE TABLE [dbo].[Venue] (
    [Id]          INT           IDENTITY (1, 1) NOT NULL,
    [Name]        VARCHAR (20)  NOT NULL,
    [Description] VARCHAR (MAX) NULL,
    [Telephone]   VARCHAR (10)  NOT NULL,
    [Email]       VARCHAR (100) NULL,
    [Address]     VARCHAR (MAX) NOT NULL,
    [latitude]    FLOAT (53)    NOT NULL,
    [longitude]   FLOAT (53)    NOT NULL,
    CONSTRAINT [PK_Venue] PRIMARY KEY CLUSTERED ([Id] ASC)
);



