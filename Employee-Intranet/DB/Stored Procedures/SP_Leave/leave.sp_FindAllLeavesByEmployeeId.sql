CREATE PROCEDURE [leave].[sp_FindAllLeavesByEmployeeId]
	@employeeId int = 0
AS
begin
	
SELECT *
  FROM [Emp_Intranet-DB].[leave].[approval] as a 
  LEFT JOIN [Emp_Intranet-DB].leave.leave_requests AS l on a.leaveid = l.Id
  WHERE l.employeeid = @employeeId

end