CREATE TABLE [dbo].[MST_RegistrationType] (
    [Id]       INT           IDENTITY (1, 1) NOT NULL,
    [Name]     VARCHAR (200) NOT NULL,
    [IsActive] BIT           NOT NULL,
    CONSTRAINT [PK_MST_RegistrationType] PRIMARY KEY CLUSTERED ([Id] ASC)
);

