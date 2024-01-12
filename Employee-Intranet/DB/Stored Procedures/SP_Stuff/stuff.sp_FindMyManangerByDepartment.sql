CREATE PROCEDURE [stuff].[sp_FindMyManangerByDepartment]
    @department NVARCHAR(50)
AS
BEGIN
    SELECT m.Id,m.manager_department,m.manager_contract,m.manager_jobtitle,m.manager_startdate, p.profile_name,p.profile_surname,p.profile_title,p.[user]
    FROM [stuff].[manager] AS m
    JOIN [user].[profile] AS p ON p.[user] = m.userid
    WHERE m.manager_department = @department;
END;