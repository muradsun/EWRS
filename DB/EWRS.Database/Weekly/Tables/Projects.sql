CREATE TABLE [Weekly].[Projects]
(
	[Project_Id] INT NOT NULL PRIMARY KEY identity(1,1), 
    [Name] VARCHAR(500) NOT NULL, 
    [PercentComplete] TINYINT NOT NULL DEFAULT 0, 
    [Status] TINYINT NOT NULL DEFAULT 1, 
    [StatusDescription] NVARCHAR(MAX) NULL, 
    [ORGANIZATION_ID] INT NOT NULL,
	[CreatedBy] [varchar](50) NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[UpdateBy] [varchar](50) NULL,
	[UpdatedDate] [datetime] NULL,
	[RowVersion] [timestamp] NOT NULL
)

GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'See 5.1.1	PROJECTS : 2. Deactivate/1. Activate, 3. Complete,  4. Close',
    @level0type = N'SCHEMA',
    @level0name = N'Weekly',
    @level1type = N'TABLE',
    @level1name = N'Projects',
    @level2type = N'COLUMN',
    @level2name = N'Status'