CREATE TABLE [Weekly].[TeamModel]
(
	[TeamModel_Id] INT NOT NULL PRIMARY KEY, 
    [User_Id] INT NOT NULL, 
    [Project_Id] INT NOT NULL,
	[IsUpdater] BIT NOT NULL
    
)
