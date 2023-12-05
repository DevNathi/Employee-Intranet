CREATE PROCEDURE [leave].[sp_FindLeaves]

AS
BEGIN
    SELECT [Id]
          ,[leave_startdate]
          ,[leave_enddate]
          ,[leave_reason]
          ,[leave_comment]
          ,[employeeid]
          ,[leavetypeid]
      FROM [Emp_Intranet-DB].[leave].[leave]
END
