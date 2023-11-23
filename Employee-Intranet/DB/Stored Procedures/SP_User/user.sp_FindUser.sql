
CREATE PROCEDURE [user].[sp_FindUser]
 @sp_email nvarchar(30),
 @sp_username nvarchar (30),
    @sp_password nvarchar(30)
AS
IF EXISTS (SELECT 1 FROM [user].[user] WHERE (user_email = @sp_email OR user_username = @sp_username) AND user_password = @sp_password)
BEGIN
    SELECT * FROM [user].[user] WHERE (user_email = @sp_email OR user_username = @sp_username) AND user_password = @sp_password;
END
--ELSE
--BEGIN
--    -- Handle the case where no user is found, maybe return an empty result or a specific value.
--    -- For example: SELECT NULL AS user_id, NULL AS user_email, NULL AS username, NULL AS user_password;
--END