CREATE TABLE [Weekly].[ProjectStatuses] (
    [ProjectStatus_Id] INT          NOT NULL,
    [Status]           VARCHAR (50) NOT NULL,
    [RowVersion]       ROWVERSION   NOT NULL,
    CONSTRAINT [PK_ProjectStatuses] PRIMARY KEY CLUSTERED ([ProjectStatus_Id] ASC)
);
GO

