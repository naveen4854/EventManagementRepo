CREATE TABLE [dbo].[Conference] (
    [Id]               INT            IDENTITY (1, 1) NOT NULL,
    [Name]             NVARCHAR (50)  NOT NULL,
    [Description]      NVARCHAR (MAX) NOT NULL,
    [ShortDescription] NVARCHAR (500) NULL,
    [Active]           BIT            NOT NULL,
    [FK_VenueId]       INT            NOT NULL,
    CONSTRAINT [PK_Conference] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Conference_Venue] FOREIGN KEY ([FK_VenueId]) REFERENCES [dbo].[Venue] ([Id])
);



