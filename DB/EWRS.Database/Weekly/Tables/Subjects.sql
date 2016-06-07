CREATE TABLE [Weekly].[Subjects]
(
	[Subject_Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Name] VARCHAR(500) NOT NULL, 
    [Template_Id] INT NOT NULL,
	[PercentComplete] tinyint DEFAULT 0,
    [DueDate] DATE NULL, 
    [IsOngoing] BIT NULL, 
    [IsMandatory] BIT NULL, 
    [IsHidden] BIT NULL,
	[CreatedBy] [varchar](50) NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[UpdateBy] [varchar](50) NULL,
	[UpdatedDate] [datetime] NULL,
	[RowVersion] [timestamp] NOT NULL
)
