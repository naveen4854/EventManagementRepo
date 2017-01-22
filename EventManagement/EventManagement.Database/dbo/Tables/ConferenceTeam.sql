CREATE TABLE [dbo].[ConferenceTeam] (
    [Id]              INT           IDENTITY (1, 1) NOT NULL,
    [FK_ConferenceId] INT           NOT NULL,
    [Name]            VARCHAR (50)  NOT NULL,
    [Info]            VARCHAR (MAX) NULL,
    [Chair]           BIT           NOT NULL,
    [Biography]       VARCHAR (MAX) NULL,
    [ImageUrl]        VARCHAR (100) NOT NULL,
    CONSTRAINT [PK_ConferenceTeam] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_ConferenceTeam_Conference] FOREIGN KEY ([FK_ConferenceId]) REFERENCES [dbo].[Conference] ([Id])
);

