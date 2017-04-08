CREATE TABLE [dbo].[Program] (
    [Id]              INT           IDENTITY (1, 1) NOT NULL,
    [Name]            VARCHAR (50)  NOT NULL,
    [Info]            VARCHAR (50)  NULL,
    [Title]           VARCHAR (200) NULL,
    [ImageUrl]        VARCHAR (50)  NULL,
    [Abstract]        VARCHAR (MAX) NULL,
    [FK_ConferenceId] INT           NOT NULL,
    [ProgramDt]       DATETIME      NOT NULL,
    [isPoster]        BIT           NOT NULL,
    CONSTRAINT [PK_Program] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Program_Conference] FOREIGN KEY ([FK_ConferenceId]) REFERENCES [dbo].[Conference] ([Id])
);



