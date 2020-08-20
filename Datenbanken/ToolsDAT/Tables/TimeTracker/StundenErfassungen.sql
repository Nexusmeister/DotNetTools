CREATE TABLE [dbo].[StundenErfassungen]
(
	[Id] INT IDENTITY(1,1) NOT NULL, 
    [ErfassungsArt] INT NOT NULL, 
    [Erfassungsdatum] DATE NOT NULL DEFAULT GETDATE(), 
    [BeginnArbeit] DATETIME NOT NULL DEFAULT GETDATE(), 
    [EndeArbeit] DATETIME NULL, 
    [Notizen] VARCHAR(1000) NULL, 
    CONSTRAINT [PK_StundenErfassungen] PRIMARY KEY (Id) 
)

GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Erfassungstag',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'StundenErfassungen',
    @level2type = N'COLUMN',
    @level2name = N'Erfassungsdatum'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'PK der Tabelle',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'StundenErfassungen',
    @level2type = N'COLUMN',
    @level2name = N'Id'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Start der Arbeit',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'StundenErfassungen',
    @level2type = N'COLUMN',
    @level2name = N'BeginnArbeit'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Ende der Arbeitszeit',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'StundenErfassungen',
    @level2type = N'COLUMN',
    @level2name = N'EndeArbeit'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Zusätzliche Notizen zum Arbeitstag',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'StundenErfassungen',
    @level2type = N'COLUMN',
    @level2name = N'Notizen'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Welche Erfassung wurde aufgenommen - Siehe Tabelle Status',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'StundenErfassungen',
    @level2type = N'COLUMN',
    @level2name = N'ErfassungsArt'