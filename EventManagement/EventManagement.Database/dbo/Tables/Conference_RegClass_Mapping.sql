CREATE TABLE [dbo].[Conference_RegClass_Mapping] (
    [Id]              INT      IDENTITY (1, 1) NOT NULL,
    [FK_ConferenceId] INT      NOT NULL,
    [FK_RegClassId]   INT      NOT NULL,
    [FromDt]          DATETIME NULL,
    [ToDt]            DATETIME NULL,
    CONSTRAINT [PK_Conference_RegClass_Mapping] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Conference_RegClass_Mapping_Conference] FOREIGN KEY ([FK_ConferenceId]) REFERENCES [dbo].[Conference] ([Id]),
    CONSTRAINT [FK_Conference_RegClass_Mapping_MST_RegistrationClass] FOREIGN KEY ([FK_RegClassId]) REFERENCES [dbo].[MST_RegistrationClass] ([Id])
);

