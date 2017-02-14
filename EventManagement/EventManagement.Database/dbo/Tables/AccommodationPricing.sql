CREATE TABLE [dbo].[AccommodationPricing] (
    [Id]                    INT IDENTITY (1, 1) NOT NULL,
    [FK_ConferenceId]       INT NOT NULL,
    [FK_AccomodationTypeId] INT NOT NULL,
    [FK_OccupancyId]        INT NOT NULL,
    [Amout]                 INT NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_AccommodationPricing_Conference] FOREIGN KEY ([FK_ConferenceId]) REFERENCES [dbo].[Conference] ([Id]),
    CONSTRAINT [FK_AccommodationPricing_MST_AccomodationType] FOREIGN KEY ([FK_AccomodationTypeId]) REFERENCES [dbo].[MST_AccomodationType] ([Id]),
    CONSTRAINT [FK_AccommodationPricing_MST_Occupancy] FOREIGN KEY ([FK_OccupancyId]) REFERENCES [dbo].[MST_Occupancy] ([Id])
);

