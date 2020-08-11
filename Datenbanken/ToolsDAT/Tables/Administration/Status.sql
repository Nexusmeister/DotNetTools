CREATE TABLE [dbo].[Status]
(
	[Id] INT NOT NULL , 
    [Tabelle] VARCHAR(50) NOT NULL, 
    [Spalte] VARCHAR(50) NOT NULL, 
    [Status] INT NOT NULL, 
    [Beschreibung] VARCHAR(75) NOT NULL, 
    CONSTRAINT [PK_Status] PRIMARY KEY (Id)
)

GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Tabelle der gesuchten Spalte',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'Status',
    @level2type = N'COLUMN',
    @level2name = N'Tabelle'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Spalte, die einen Status repräsentiert',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'Status',
    @level2type = N'COLUMN',
    @level2name = N'Spalte'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Definierter Statuswert',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'Status',
    @level2type = N'COLUMN',
    @level2name = N'Status'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Beschreibung des Statuswert',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'Status',
    @level2type = N'COLUMN',
    @level2name = N'Beschreibung'