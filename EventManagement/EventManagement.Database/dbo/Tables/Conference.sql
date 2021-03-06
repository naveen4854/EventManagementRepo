﻿CREATE TABLE [dbo].[Conference] (
    [Id]               INT            IDENTITY (1, 1) NOT NULL,
    [Name]             VARCHAR (MAX)  NULL,
    [Description]      NVARCHAR (MAX) NOT NULL,
    [ShortDescription] NVARCHAR (500) NULL,
    [Active]           BIT            NOT NULL,
    [FK_VenueId]       INT            NOT NULL,
    [startDt]          DATETIME       NOT NULL,
    [endDt]            DATETIME       NOT NULL,
    [brochure]         VARCHAR (100)  NULL,
    [SpeakerList]      VARCHAR (100)  NULL,
    [shortImageUrl]    VARCHAR (MAX)  NOT NULL,
    [DisplayId]        VARCHAR (MAX)  NOT NULL,
    [ConfEmail]        VARCHAR (MAX)  NULL,
    CONSTRAINT [PK_Conference] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Conference_Venue] FOREIGN KEY ([FK_VenueId]) REFERENCES [dbo].[Venue] ([Id])
);















