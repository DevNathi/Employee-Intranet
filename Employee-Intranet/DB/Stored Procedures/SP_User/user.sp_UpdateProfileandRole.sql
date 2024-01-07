CREATE PROCEDURE [user].[sp_UpdateProfileandRole]
    @userID INT,
    @newName NVARCHAR(255),
    @newSurname NVARCHAR(255),
    @newTitle NCHAR(10)
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRY
        BEGIN TRANSACTION;

        -- Update ProfileTable
        UPDATE [user].[profile] 
        SET [profile_name] = @newName, [profile_surname] = @newSurname, [profile_title] = @newTitle
        WHERE [profile].[user] = @userID;


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