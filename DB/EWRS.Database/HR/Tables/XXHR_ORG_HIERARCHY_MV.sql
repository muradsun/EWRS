CREATE TABLE [HR].[XXHR_ORG_HIERARCHY_MV](
	[ORGNAME] [nvarchar](240) NOT NULL,
	[ORGID] [numeric](15, 0) NOT NULL,
	[ORGTYPE] [nvarchar](30) NULL,
	[BU_NAME] [nvarchar](4000) NULL,
	[BU_ID] [nvarchar](4000) NULL,
	[DIV_NAME] [nvarchar](4000) NULL,
	[DIV_ID] [nvarchar](4000) NULL,
	[DEP_NAME] [nvarchar](4000) NULL,
	[DEP_ID] [nvarchar](4000) NULL,
	[TEAM_NAME] [nvarchar](4000) NULL,
	[TEAM_ID] [nvarchar](4000) NULL,
	[SECTION_NAME] [nvarchar](4000) NULL,
	[SECTION_ID] [nvarchar](4000) NULL
) ON [PRIMARY]