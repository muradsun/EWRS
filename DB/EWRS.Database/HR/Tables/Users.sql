
CREATE TABLE [HR].[Users](
	[User_Id] [int] IDENTITY(1,1) NOT NULL,
	[PF_NO] [varchar](10) NOT NULL,
	[FIRST_NAME] [varchar](250) NOT NULL,
	[FAMILY_NAME] [varchar](250) NOT NULL,
	[LOCATION] [varchar](50) NOT NULL,
	[ENGAGEMENT_TYPE] [varchar](50) NOT NULL,
	[POSITION_ID] [int] NULL,
	[POST_TITLE_LONG_DESC] [varchar](500) NULL,
	[ORGANIZATION_ID] [int] NOT NULL,
	[ReportTo] [int] NULL,
	[FromHRMS] [bit] NULL,
	[CreatedBy] [varchar](50) NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[UpdateBy] [varchar](50) NULL,
	[UpdatedDate] [datetime] NULL,
	[RowVersion] [timestamp] NOT NULL,
	[POSITION_ORG_LEVEL] [nvarchar](400) NULL,
	[REPORTING_TO_POS_ORG_LEVEL] [nvarchar](400) NULL,
	[REP_TO_POSITION_ID] [int] NULL,
 CONSTRAINT [PK__Users__206D9170903413CF] PRIMARY KEY CLUSTERED 
(
	[User_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]