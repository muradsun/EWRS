CREATE TABLE [System].[Configurations]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Key] VARCHAR(MAX) NOT NULL, 
    [Value] VARCHAR(MAX) NOT NULL, 
    [RefId] INT NOT NULL,
	[CreatedBy] [varchar](50) NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[UpdateBy] [varchar](50) NULL,
	[UpdatedDate] [datetime] NULL,
	[RowVersion] [timestamp] NOT NULL

)
