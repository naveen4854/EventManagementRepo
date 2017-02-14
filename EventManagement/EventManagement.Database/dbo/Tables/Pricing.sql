CREATE TABLE [dbo].[Pricing] (
    [Id]              INT IDENTITY (1, 1) NOT NULL,
    [FK_ConferenceId] INT NOT NULL,
    [FK_RegType]      INT NOT NULL,
    [FK_RegClass]     INT NOT NULL,
    [Amout]           INT NOT NULL,
    CONSTRAINT [PK_Pricing] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Pricing_Conference] FOREIGN KEY ([FK_ConferenceId]) REFERENCES [dbo].[Conference] ([Id]),
    CONSTRAINT [FK_Pricing_MST_RegistrationClass] FOREIGN KEY ([FK_RegClass]) REFERENCES [dbo].[MST_RegistrationClass] ([Id]),
    CONSTRAINT [FK_Pricing_MST_RegistrationType] FOREIGN KEY ([FK_RegType]) REFERENCES [dbo].[MST_RegistrationType] ([Id])
);

