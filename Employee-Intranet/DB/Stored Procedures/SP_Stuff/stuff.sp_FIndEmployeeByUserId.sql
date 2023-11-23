CREATE PROCEDURE [stuff].[sp_FIndEmployeeByUserId]
		@userId int = 0
AS
begin
	

SELECT TOP 1 *
  FROM [stuff].[employee]
  where @userId = userid

end
