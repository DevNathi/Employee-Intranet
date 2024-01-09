CREATE PROCEDURE [stuff].[sp_FindMyColleageas]
    @colleagues NVARCHAR(50)
AS
BEGIN
   SELECT *
FROM [stuff].[employee] AS e
Left Join [user].[profile] AS p ON E.userid = P.[user]
WHERE E.employee_department = @colleagues;
END;