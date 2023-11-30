CREATE PROCEDURE [stuff].[sp_FIndEmployeeByUserId]
		@userId int = 0
AS
IF EXISTS (SELECT 1 FROM [stuff].[employee] WHERE(userid = @userId))
BEGIN
   SELECT TOP 1 *
   FROM [stuff].[employee] E
   LEFT JOIN [stuff].[department] D ON E.departmentid = D.Id
   WHERE E.userid = @userId;

END
ELSE
BEGIN
    SELECT NULL;
END
