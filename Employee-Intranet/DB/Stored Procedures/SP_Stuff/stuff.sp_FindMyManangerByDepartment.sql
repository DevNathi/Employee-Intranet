CREATE PROCEDURE [stuff].[sp_FindMyManangerByDepartment]
    @department NVARCHAR(50)
AS
BEGIN
    SELECT *
    FROM [stuff].[manager] AS m
    JOIN [user].[profile] AS p ON p.[user] = m.userid
    WHERE m.manager_department = @department;
END;