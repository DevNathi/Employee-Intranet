CREATE PROCEDURE [leave].[sp_TotalLeavesPerStatusForEmployee]
	@userId int
AS
BEGIN
SELECT
    e.Id,
    e.userid,
    COUNT(CASE WHEN a.approval_status = 'Pending' THEN 1 END) AS TotalPendingLeave,
    COUNT(CASE WHEN a.approval_status = 'Approved' THEN 1 END) AS TotalApprovedLeaves
FROM
    [Emp_Intranet-DB].[leave].leave_requests AS l
JOIN
    [Emp_Intranet-DB].[leave].approval AS a ON l.Id = a.leaveid
JOIN
    [Emp_Intranet-DB].[stuff].[employee] AS e ON l.employeeid = e.Id

WHERE
e.Id = 1 AND
    YEAR(l.leave_startdate) = 2024
GROUP BY
    e.Id, e.userid;
END