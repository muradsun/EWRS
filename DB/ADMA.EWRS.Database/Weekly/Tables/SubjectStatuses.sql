CREATE TABLE [Weekly].[SubjectStatuses] (
    [SubjectStatus_Id] INT          NOT NULL,
    [Status]           VARCHAR (50) NOT NULL,
    [RowVersion]       ROWVERSION   NOT NULL,
    CONSTRAINT [PK_SubjectStatuses] PRIMARY KEY CLUSTERED ([SubjectStatus_Id] ASC)
);





