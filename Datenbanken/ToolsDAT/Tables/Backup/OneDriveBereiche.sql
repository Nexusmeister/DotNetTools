CREATE TABLE [dbo].[OneDriveBereiche]
(
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Pfad] [varchar](250) NOT NULL,
	[AufgabenNr] [int] NOT NULL,
 CONSTRAINT [PK_OneDriveBereiche] PRIMARY KEY CLUSTERED (	[Id] ASC ), 
    CONSTRAINT [FK_OneDriveBereiche_BackupAufgaben] FOREIGN KEY (AufgabenNr) REFERENCES BackupAufgaben(Id)
)
GO

EXEC sp_addextendedproperty @name=N'MS_Description', @value=N'BereichsNr' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'OneDriveBereiche', @level2type=N'COLUMN',@level2name=N'Id'
GO

EXEC sp_addextendedproperty @name=N'MS_Description', @value=N'Pfad des Bereichs' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'OneDriveBereiche', @level2type=N'COLUMN',@level2name=N'Pfad'
GO

EXEC sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel auf Tabelle BackupAufgaben' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'OneDriveBereiche', @level2type=N'COLUMN',@level2name=N'AufgabenNr'
GO