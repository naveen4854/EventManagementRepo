CREATE TABLE [dbo].[MST_Accompany] (
    [Id]       INT          IDENTITY (1, 1) NOT NULL,
    [Name]     VARCHAR (20) NOT NULL,
    [Value]    INT          NOT NULL,
    [isActive] BIT          NOT NULL,
    CONSTRAINT [PK_MST_Accompany] PRIMARY KEY CLUSTERED ([Id] ASC)
);

