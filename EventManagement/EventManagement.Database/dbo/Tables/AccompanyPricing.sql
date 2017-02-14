CREATE TABLE [dbo].[AccompanyPricing] (
    [Id]              INT IDENTITY (1, 1) NOT NULL,
    [FK_conferenceId] INT NOT NULL,
    [FK_AccompanyId]  INT NOT NULL,
    [Amount]          INT NOT NULL,
    CONSTRAINT [PK_AccompanyPricing] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_AccompanyPricing_Conference] FOREIGN KEY ([FK_conferenceId]) REFERENCES [dbo].[Conference] ([Id]),
    CONSTRAINT [FK_AccompanyPricing_MST_Accompany] FOREIGN KEY ([FK_AccompanyId]) REFERENCES [dbo].[MST_Accompany] ([Id])
);

