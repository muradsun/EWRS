CREATE TABLE [Weekly].[Templates]
(
	[Template_Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Name] NVARCHAR(500) NOT NULL, 
    [Project_Id] INT NOT NULL,
	[CreatedBy] [varchar](50) NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[UpdateBy] [varchar](50) NULL,
	[UpdatedDate] [datetime] NULL,
	[RowVersion] [timestamp] NOT NULL,

)
