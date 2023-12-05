CREATE PROCEDURE [stuff].[sp_UpdateEmployee]

    @newDepartmentID INT,
    @userID INT,
    @newJobtitle NVARCHAR(255),
    @newContract NVARCHAR(255),
    @newStartdate Datetime,
    @newDepertment NVARCHAR (255),
    @newDepertmentSize NVARCHAR(255),
    @newDepertmentManager NVARCHAR (255),
    @newDepertmentLocation NVARCHAR (255)
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRY
        BEGIN TRANSACTION;

        -- Update Employee
        UPDATE [stuff].[employee] 
        SET [employee_jobtitle] = @newJobtitle,[employee_contract] = @newContract,[employee_startdate] = @newStartdate
        WHERE [employee].[userid] = @userID;

        -- Update Department
        UPDATE [stuff].[department]
        SET [department_name] = @newDepertment,[department_manager] = @newDepertmentManager,[department_location] = @newDepertmentLocation,[department_size] = @newDepertmentSize
        WHERE [Id] = @newDepartmentID;

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