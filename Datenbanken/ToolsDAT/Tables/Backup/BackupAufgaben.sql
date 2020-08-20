CREATE TABLE [dbo].[BackupAufgaben]
(
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ReihenfolgeNr] [int] NOT NULL,
	[ZipName] [varchar](100) NOT NULL,
	CONSTRAINT [PK_BackupAufgaben] PRIMARY KEY CLUSTERED (	[Id] ASC )
)

GO
EXEC sp_addextendedproperty @name=N'MS_Description', @value=N'AufgabenNr' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BackupAufgaben', @level2type=N'COLUMN',@level2name=N'Id'
GO

EXEC sp_addextendedproperty @name=N'MS_Description', @value=N'Definiert die Reihenfolge der einzelnen BackupAufgaben' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BackupAufgaben', @level2type=N'COLUMN',@level2name=N'ReihenfolgeNr'
GO

EXEC sp_addextendedproperty @name=N'MS_Description', @value=N'[ReihenfolgeNr]_[Bereich].zip' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BackupAufgaben', @level2type=N'COLUMN',@level2name=N'ZipName'
GO
