CREATE TABLE [Weekly].[ProjectStatuses] (
    [ProjectStatus_Id] TINYINT      IDENTITY (1, 1) NOT NULL,
    [Status]           VARCHAR (50) NOT NULL,
    [RowVersion]       ROWVERSION   NOT NULL,
    CONSTRAINT [PK_ProjectStatuses] PRIMARY KEY CLUSTERED ([ProjectStatus_Id] ASC)
);

