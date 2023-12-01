CREATE PROCEDURE [leave].[sp_FindAllLeaveTypes]

AS
BEGIN
    SELECT *
      FROM [leave].[type]
END
