CREATE TABLE [dbo].[Registrations_Log] (
    [Id]              INT           IDENTITY (1, 1) NOT NULL,
    [SubmittedBy]     VARCHAR (MAX) NOT NULL,
    [EmailId]         VARCHAR (MAX) NOT NULL,
    [Telephone]       VARCHAR (10)  NOT NULL,
    [Organisation]    VARCHAR (MAX) NOT NULL,
    [FK_CountryId]    INT           NOT NULL,
    [Address]         VARCHAR (MAX) NOT NULL,
    [FK_ConferenceId] INT           NOT NULL,
    [FK_RegTypeId]    INT           NOT NULL,
    [FK_RegClassId]   INT           NOT NULL,
    [FK_StatusId]     INT           NOT NULL,
    [TotalPrice]      FLOAT (53)    NOT NULL,
    [Description]     VARCHAR (MAX) NULL,
    CONSTRAINT [PK_Registrations_Log] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Registrations_Log_Conference] FOREIGN KEY ([FK_ConferenceId]) REFERENCES [dbo].[Conference] ([Id]),
    CONSTRAINT [FK_Registrations_Log_Country] FOREIGN KEY ([FK_CountryId]) REFERENCES [dbo].[Country] ([Id]),
    CONSTRAINT [FK_Registrations_Log_MST_RegistrationClass] FOREIGN KEY ([FK_RegClassId]) REFERENCES [dbo].[MST_RegistrationClass] ([Id]),
    CONSTRAINT [FK_Registrations_Log_MST_RegistrationType] FOREIGN KEY ([FK_RegTypeId]) REFERENCES [dbo].[MST_RegistrationType] ([Id])
);



