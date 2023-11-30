CREATE PROCEDURE [user].[FIndProfileandRoleAfterLogin]
    @sp_userID int
AS
IF EXISTS (SELECT 1 FROM [user].[profile] WHERE [user] = @sp_userID )
BEGIN
    SELECT *
  FROM [Emp_Intranet-DB].[user].[profile] P
  left join 
  [Emp_Intranet-DB].[user].[roles] R ON P.[role] = R.Id

  Where p.[user] = @sp_userID;
END
ELSE
BEGIN
    SELECT NULL AS user_id, NULL AS user_email, NULL AS username, NULL AS user_password;
END

