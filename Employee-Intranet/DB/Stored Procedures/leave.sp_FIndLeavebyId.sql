CREATE PROCEDURE [leave].[sp_FIndLeavebyId]
	@Id int = 0
AS
begin
	

SELECT [Id]
      ,[leave_startdate]
      ,[leave_enddate]
      ,[leave_reason]
      ,[leave_comment]
      ,[employeeid]
      ,[permissionid]
      ,[leavetypeid]
  FROM [Emp_Intranet-DB].[leave].[leave]
  where @Id = [Id]

end
