CREATE TABLE [dbo].[Customizing]
(
	[Id] INT IDENTITY(1,1) NOT NULL , 
    [Beschreibung] VARCHAR(250) NOT NULL, 
    [Anlagedatum] DATETIME NOT NULL DEFAULT GETDATE(), 
    [Aenderungsdatum] DATETIME NULL, 
    [StringWert] VARCHAR(200) NULL, 
    [IntWert] INT NULL, 
    CONSTRAINT [PK_Customizing] PRIMARY KEY (Id)
)

GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Beschreibung des Customizing-Eintrags',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'Customizing',
    @level2type = N'COLUMN',
    @level2name = N'Beschreibung'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Anlagezeitpunkt des Eintrags',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'Customizing',
    @level2type = N'COLUMN',
    @level2name = N'Anlagedatum'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'String Customizing',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'Customizing',
    @level2type = N'COLUMN',
    @level2name = N'StringWert'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Integer Customizing',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'Customizing',
    @level2type = N'COLUMN',
    @level2name = N'IntWert'
GO

CREATE INDEX [IX_Customizing_Id] ON [dbo].[Customizing] (Id)

GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Zeitpunkt der letzten Änderung',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'Customizing',
    @level2type = N'COLUMN',
    @level2name = N'Aenderungsdatum'