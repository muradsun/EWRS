CREATE TABLE [HR].[Users] (
    [User_Id]                 INT           IDENTITY (1, 1) NOT NULL,
    [PF_NO]                   VARCHAR (10)  NOT NULL,
    [FIRST_NAME]              VARCHAR (250) NOT NULL,
    [FAMILY_NAME]             VARCHAR (250) NOT NULL,
    [EMPLOYEE_NAME]           VARCHAR (250) NOT NULL,
    [POST_TITLE_LONG_DESC]    VARCHAR (500) NOT NULL,
    [LOCATION]                VARCHAR (50)  NOT NULL,
    [ENGAGEMENT_TYPE]         VARCHAR (50)  NOT NULL,
    [GENDER]                  TINYINT       NOT NULL,
    [EMAIL]                   VARCHAR (250) NOT NULL,
    [OFFICE_TELEPHONE_NUMBER] VARCHAR (50)  NULL,
    [OFFICE_LOCATION]         VARCHAR (50)  NULL,
    [EMPLOYMENT_TYPE]         VARCHAR (50)  NOT NULL,
    [POSITION_ID]             INT           NOT NULL,
    [ORGANIZATION_ID]         INT           NOT NULL,
    [IsFromHRMS]              BIT           NULL,
    [IsActive]                BIT           NOT NULL,
    [CreatedBy]               VARCHAR (50)  NOT NULL,
    [CreatedDate]             DATETIME      NOT NULL,
    [UpdateBy]                VARCHAR (50)  NULL,
    [UpdatedDate]             DATETIME      NULL,
    [RowVersion]              ROWVERSION    NOT NULL,
    CONSTRAINT [PK__Users__206D9170903413CF] PRIMARY KEY CLUSTERED ([User_Id] ASC)
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'in Abu Dhabi or Offsure', @level0type = N'SCHEMA', @level0name = N'HR', @level1type = N'TABLE', @level1name = N'Users', @level2type = N'COLUMN', @level2name = N'LOCATION';

