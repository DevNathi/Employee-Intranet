CREATE PROCEDURE [user].[FindProfileAfterLogin]
    @sp_userID int
AS
IF EXISTS (SELECT 1 FROM [user].[profile] WHERE [user] = @sp_userID )
BEGIN
    SELECT *
  FROM [Emp_Intranet-DB].[user].[profile] P
  
  Where p.[user] = @sp_userID;
END
ELSE
BEGIN
    SELECT NULL AS user_id, NULL AS user_email, NULL AS username, NULL AS user_password;
END

