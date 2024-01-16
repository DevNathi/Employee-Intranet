CREATE PROCEDURE [leave].[sp_FindLeaveById]
	@leaveId int 
AS
BEGIN
SELECT *
FROM leave.leave_requests as l
LEFT JOIN leave.approval as a on l.Id = a.leaveid
where l.Id = @leaveId;
END