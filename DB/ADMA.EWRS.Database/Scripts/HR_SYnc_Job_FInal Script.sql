Update HR.Users 
SET    [PF_NO]					= v.[PF_NO]						
      ,[FIRST_NAME]				= v.[FIRST_NAME]					
      ,[FAMILY_NAME]			= v.[FAMILY_NAME]				
      ,[LOCATION]				= v.[LOCATION]					
      ,[ENGAGEMENT_TYPE]		= ISNULL(v.[ENGAGEMENT_TYPE],'N/A')			
      ,[POSITION_ID]			= v.[POSITION_ID]				
      ,[POST_TITLE_LONG_DESC]	= v.[POST_TITLE_LONG_DESC]		
      ,[ORGANIZATION_ID]		= v.[ORGANIZATION_ID]		
	  ,[IsFromHRMS]				= 1	
	  ,[UpdateBy]				= 'SysAdmin'	
FROM  HR.HR_EMP_INFO_V AS V INNER JOIN HR.Users AS U ON v.PF_NO = u.PF_NO AND TERMINATION_DATE IS NULL
--WHERE U.PF_NO IN ( SELECT PF_NO FROM HR.Users ) 


--Refresh Users - New
INSERT INTO [HR].[Users]
           ([PF_NO]
           ,[FIRST_NAME]
           ,[FAMILY_NAME]
           ,[EMPLOYEE_NAME]
           ,[POST_TITLE_LONG_DESC]
           ,[LOCATION]
           ,[ENGAGEMENT_TYPE]
           ,[GENDER]
           ,[EMAIL]
           ,[OFFICE_TELEPHONE_NUMBER]
           ,[OFFICE_LOCATION]
           ,[EMPLOYMENT_TYPE]
           ,[POSITION_ID]
           ,[ORGANIZATION_ID]
           ,[IsFromHRMS]
           ,[IsActive]
           ,[CreatedBy]
           ,[CreatedDate]
           ,[UpdateBy]
           ,[UpdatedDate]
		   )
SELECT		v.[PF_NO]
           ,v.[FIRST_NAME]
           ,v.[FAMILY_NAME]
           ,v.[EMPLOYEE_NAME]
           ,v.[POST_TITLE_LONG_DESC]
           ,v.[LOCATION]
           , ISNULL(v.[ENGAGEMENT_TYPE],'N/A')
           ,v.[GENDER]
           , ISNULL(v.[EMAIL],'N/A') 
           ,v.[OFFICE_TELEPHONE_NUMBER]
           ,v.[OFFICE_LOCATION]
           ,v.[EMPLOYMENT_TYPE]
           ,v.[POSITION_ID]
           ,v.[ORGANIZATION_ID]
           ,1
           ,1
           ,'SysAdmin'
           ,GETDATE()
           ,NULL
           ,NULL
FROM  HR.HR_EMP_INFO_V AS v
WHERE PF_NO NOT IN ( SELECT PF_NO FROM HR.Users )  AND TERMINATION_DATE IS NULL


-- Emsure data integrity 
Update	HR.USers 
SET		[IsFromHRMS]  = 0
WHERE	(PF_NO NOT IN 
			(SELECT PF_NO FROM HR.HR_EMP_INFO_V )
		)

