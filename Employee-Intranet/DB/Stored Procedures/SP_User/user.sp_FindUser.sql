
CREATE PROCEDURE [user].[sp_FindUser]
    @sp_email nvarchar(30),
    @sp_password nvarchar(30)
AS
BEGIN
    SELECT * FROM [user].[user] WHERE (user_email = @sp_email) AND user_password = @sp_password;
END