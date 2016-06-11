CREATE TABLE [Sec].[Delegations] (
    [Delegation_Id] INT  NOT NULL,
    [User_Id]       INT  NOT NULL,
    [FromDate]      DATE NOT NULL,
    [ToDate]        DATE NOT NULL,
    PRIMARY KEY CLUSTERED ([Delegation_Id] ASC)
);

