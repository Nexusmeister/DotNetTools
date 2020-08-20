CREATE TABLE [dbo].[BackupSchedule](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[AufgabenId] [int] NOT NULL,
	[Datum] [date] NOT NULL,
	[BackupGroesse] [decimal](18, 4) NULL,
	[BackupDauer] [decimal](18, 4) NULL,
	[Status] [int] NOT NULL DEFAULT 0,
	CONSTRAINT [PK_BackupSchedule] PRIMARY KEY CLUSTERED (	[Id] ASC ), 
    CONSTRAINT [FK_BackupSchedule_BackupAufgaben] FOREIGN KEY (AufgabenId) REFERENCES BackupAufgaben(Id)
)
GO

EXEC sp_addextendedproperty @name=N'MS_Description', @value=N'ScheduleNr' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BackupSchedule', @level2type=N'COLUMN',@level2name=N'Id'
GO

EXEC sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel zu Aufgabe' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BackupSchedule', @level2type=N'COLUMN',@level2name=N'AufgabenId'
GO

EXEC sp_addextendedproperty @name=N'MS_Description', @value=N'Datum der Ausführung' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BackupSchedule', @level2type=N'COLUMN',@level2name=N'Datum'
GO

EXEC sp_addextendedproperty @name=N'MS_Description', @value=N'Zeigt Größe des Backups in MB' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BackupSchedule', @level2type=N'COLUMN',@level2name=N'BackupGroesse'
GO

EXEC sp_addextendedproperty @name=N'MS_Description', @value=N'Dauer des Backups in Sekunden' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BackupSchedule', @level2type=N'COLUMN',@level2name=N'BackupDauer'
GO

EXEC sp_addextendedproperty @name=N'MS_Description', @value=N'Siehe Tabelle Status' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BackupSchedule', @level2type=N'COLUMN',@level2name=N'Status'
GO
