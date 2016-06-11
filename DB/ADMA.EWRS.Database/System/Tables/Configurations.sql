CREATE TABLE [System].[Configurations] (
    [Id]          INT           NOT NULL,
    [Key]         VARCHAR (MAX) NOT NULL,
    [Value]       VARCHAR (MAX) NOT NULL,
    [RefId]       INT           NOT NULL,
    [CreatedBy]   VARCHAR (50)  NOT NULL,
    [CreatedDate] DATETIME      NOT NULL,
    [UpdateBy]    VARCHAR (50)  NULL,
    [UpdatedDate] DATETIME      NULL,
    [RowVersion]  ROWVERSION    NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

