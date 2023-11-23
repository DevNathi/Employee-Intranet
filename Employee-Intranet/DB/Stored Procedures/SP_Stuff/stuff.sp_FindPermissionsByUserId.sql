CREATE PROCEDURE [stuff].[sp_FindPermissionsByUserId]
		@userId int = 0
AS
begin
	

SELECT TOP 1 *
  FROM [stuff].[permissions]
  where @userId = [Id]

end
