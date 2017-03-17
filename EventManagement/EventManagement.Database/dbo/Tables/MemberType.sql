CREATE TABLE [dbo].[MemberType] (
    [Id]          INT           IDENTITY (1, 1) NOT NULL,
    [Type]        VARCHAR (100) NOT NULL,
    [Description] VARCHAR (MAX) NULL,
    CONSTRAINT [PK_MemberType] PRIMARY KEY CLUSTERED ([Id] ASC)
);

