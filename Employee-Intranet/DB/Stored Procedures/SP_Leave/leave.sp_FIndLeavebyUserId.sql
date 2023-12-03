CREATE PROCEDURE [leave].[sp_FIndLeavebyUserId]
	@Id int = 0
AS
begin
	
SELECT *
FROM [leave].[leave] L
LEFT JOIN
[leave].[type] T ON L.leavetypeid = T.Id
WHERE L.employeeid = @Id;

end