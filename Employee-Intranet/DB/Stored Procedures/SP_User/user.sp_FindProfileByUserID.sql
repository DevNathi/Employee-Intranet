CREATE PROCEDURE [user].[sp_FindProfileByUserID]
	@Id int = 0
AS
begin
	

SELECT TOP 1 *
  FROM [user].[profile]
  where @Id = [user]

end
