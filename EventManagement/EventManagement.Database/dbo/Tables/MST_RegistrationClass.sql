CREATE TABLE [dbo].[MST_RegistrationClass] (
    [Id]       INT           IDENTITY (1, 1) NOT NULL,
    [Name]     VARCHAR (200) NOT NULL,
    [IsActive] BIT           NOT NULL,
    CONSTRAINT [PK_MST_RegistrationClass] PRIMARY KEY CLUSTERED ([Id] ASC)
);

