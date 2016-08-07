--Delete Existing Records if found - disable identity.
DELETE FROM [Weekly].[SubjectStatuses]
GO

INSERT INTO [Weekly].[SubjectStatuses]
           ([SubjectStatus_Id]
           ,[Status])
     VALUES
           (1
           ,'Draft')
GO


INSERT INTO [Weekly].[SubjectStatuses]
           ([SubjectStatus_Id]
           ,[Status])
     VALUES
           (2
           ,'Deleted')
GO

INSERT INTO [Weekly].[SubjectStatuses]
           ([SubjectStatus_Id]
           ,[Status])
     VALUES
           (3
           ,'Activate')
GO

INSERT INTO [Weekly].[SubjectStatuses]
           ([SubjectStatus_Id]
           ,[Status])
     VALUES
           (4
           ,'Deactivate')
GO


INSERT INTO [Weekly].[SubjectStatuses]
           ([SubjectStatus_Id]
           ,[Status])
     VALUES
           (5
           ,'Completed')
GO

INSERT INTO [Weekly].[SubjectStatuses]
           ([SubjectStatus_Id]
           ,[Status])
     VALUES
           (6
           ,'Closed')
GO

