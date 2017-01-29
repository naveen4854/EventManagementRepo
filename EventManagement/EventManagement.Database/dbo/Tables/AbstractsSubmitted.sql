CREATE TABLE [dbo].[AbstractsSubmitted] (
    [Id]              INT           IDENTITY (1, 1) NOT NULL,
    [SubmittedBy]     VARCHAR (MAX) NOT NULL,
    [EmailId]         VARCHAR (MAX) NOT NULL,
    [Telephone]       VARCHAR (10)  NULL,
    [Organisation]    VARCHAR (MAX) NULL,
    [FK_CategoryId]   INT           NOT NULL,
    [FK_TrackID]      INT           NOT NULL,
    [DocName]         VARCHAR (MAX) NOT NULL,
    [FK_TitleId]      INT           NOT NULL,
    [FK_ContryId]     INT           NOT NULL,
    [FK_ConferenceId] INT           NOT NULL,
    CONSTRAINT [PK_AbstractsSubmitted] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_AbstractsSubmitted_Category] FOREIGN KEY ([FK_CategoryId]) REFERENCES [dbo].[Category] ([Id]),
    CONSTRAINT [FK_AbstractsSubmitted_Conference] FOREIGN KEY ([FK_ConferenceId]) REFERENCES [dbo].[Conference] ([Id]),
    CONSTRAINT [FK_AbstractsSubmitted_Country] FOREIGN KEY ([FK_ContryId]) REFERENCES [dbo].[Country] ([Id]),
    CONSTRAINT [FK_AbstractsSubmitted_Title] FOREIGN KEY ([FK_TitleId]) REFERENCES [dbo].[Title] ([Id]),
    CONSTRAINT [FK_AbstractsSubmitted_Track] FOREIGN KEY ([FK_TrackID]) REFERENCES [dbo].[Track] ([Id])
);



