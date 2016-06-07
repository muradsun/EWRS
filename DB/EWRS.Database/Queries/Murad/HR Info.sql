select * from openquery(HRPREPRD, 'select * from xxhr_int.HR_EMP_INFO_V where PF_no = ''053631''  OR PF_no = ''050509'' ')
select * from openquery(HRPREPRD, 'select * from xxhr_int.POSITION_HIREARCHY')



SELECT  [%Complete]
FROM [Weekly].[Projects]

