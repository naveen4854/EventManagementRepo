CREATE TABLE [dbo].[MST_Occupancy] (
    [Id]       INT           IDENTITY (1, 1) NOT NULL,
    [Name]     VARCHAR (500) NOT NULL,
    [IsActive] BIT           NOT NULL,
    [OccValue] INT           NULL,
    CONSTRAINT [PK_MST_Occupancy] PRIMARY KEY CLUSTERED ([Id] ASC)
);

