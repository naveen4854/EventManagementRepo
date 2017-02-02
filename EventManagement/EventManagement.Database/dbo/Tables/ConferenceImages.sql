CREATE TABLE [dbo].[ConferenceImages] (
    [Id]              INT           IDENTITY (1, 1) NOT NULL,
    [FK_ConferenceId] INT           NOT NULL,
    [ImageUrl]        VARCHAR (MAX) NOT NULL,
    [Active]          BIT           NOT NULL,
    CONSTRAINT [PK_ConferenceImages] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_ConferenceImages_Conference] FOREIGN KEY ([FK_ConferenceId]) REFERENCES [dbo].[Conference] ([Id])
);



