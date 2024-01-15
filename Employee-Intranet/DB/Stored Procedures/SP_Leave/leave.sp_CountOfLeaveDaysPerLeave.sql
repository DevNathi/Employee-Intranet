CREATE PROCEDURE [leave].[sp_CountOfLeaveDaysPerLeave]
	@employeeId int 
AS
	BEGIN
SELECT [leave_name], SUM(DATEDIFF(day, [leave_startdate], [leave_enddate])) AS TotalDaysTakenPerLeave
FROM [Emp_Intranet-DB].[leave].leave_requests
WHERE [employeeid] = @employeeId
GROUP BY [leave_name];

SELECT SUM(DATEDIFF(day, [leave_startdate], [leave_enddate])) AS TotalDaysTakenInTotal
FROM [Emp_Intranet-DB].[leave].leave_requests
WHERE [employeeid] = @employeeId;
END
