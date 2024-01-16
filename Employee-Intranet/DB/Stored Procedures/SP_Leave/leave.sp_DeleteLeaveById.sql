CREATE PROCEDURE [leave].[sp_DeleteLeaveById]
	@leaveId int
AS
BEGIN

DELETE 
FROM leave.approval
where leaveid = @leaveId;

DELETE
FROM leave.leave_requests
WHERE	Id = @leaveId;

END