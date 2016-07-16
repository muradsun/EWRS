CREATE TABLE [HR].[XXHR_ORG_HIERARCHY_MV] (
    [ORGNAME]      NVARCHAR (240)  NOT NULL,
    [ORGID]        INT             NOT NULL,
    [ORGTYPE]      NVARCHAR (30)   NULL,
    [BU_NAME]      NVARCHAR (4000) NULL,
    [BU_ID]        INT             NULL,
    [DIV_NAME]     NVARCHAR (4000) NULL,
    [DIV_ID]       INT             NULL,
    [DEP_NAME]     NVARCHAR (4000) NULL,
    [DEP_ID]       INT             NULL,
    [TEAM_NAME]    NVARCHAR (4000) NULL,
    [TEAM_ID]      INT             NULL,
    [SECTION_NAME] NVARCHAR (4000) NULL,
    [SECTION_ID]   INT             NULL
);



