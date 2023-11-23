CREATE PROCEDURE [stuff].[sp_Find DepartmentById]
	@Id int = 0
AS
begin
	

SELECT TOP 1 *
  FROM [stuff].[department]
  where @Id = [Id]

end
