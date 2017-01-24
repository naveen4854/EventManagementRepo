CREATE TABLE [dbo].[Track] (
    [Id]              INT           IDENTITY (1, 1) NOT NULL,
    [Name]            VARCHAR (100) NOT NULL,
    [Description]     VARCHAR (MAX) NULL,
    [FK_ConferenceId] INT           NOT NULL,
    CONSTRAINT [PK_Track] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Track_Conference] FOREIGN KEY ([FK_ConferenceId]) REFERENCES [dbo].[Conference] ([Id])
);

