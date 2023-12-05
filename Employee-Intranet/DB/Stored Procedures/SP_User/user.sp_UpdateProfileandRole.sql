CREATE PROCEDURE [user].[sp_UpdateProfileandRole]
    @userID INT,
    @newName NVARCHAR(255),
    @newSurname NVARCHAR(255),
    @newTitle NCHAR(10),
	@newRole NVARCHAR(255),
	@newRoleId INT,
    @newUser INT
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRY
        BEGIN TRANSACTION;

        -- Update ProfileTable
        UPDATE [user].[profile] 
        SET [profile_name] = @newName, [profile_surname] = @newSurname, [profile_title] = @newTitle
        WHERE [profile].[user] = @userID;

        -- Update ProfileTable
        UPDATE [user].[roles]
        SET role_name = @newRole
        WHERE [Id] = @newRoleId;

        -- Commit the transaction if all updates succeed
        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        -- An error occurred, rollback the transaction
        ROLLBACK TRANSACTION;

        -- Propagate the error
        THROW;
    END CATCH;
END;