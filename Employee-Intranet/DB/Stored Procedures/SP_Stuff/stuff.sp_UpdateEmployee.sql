CREATE PROCEDURE [stuff].[sp_UpdateEmployee]

    @e_userid INT,
    @e_startdate DATE,
    @e_contract NVARCHAR(255),
    @e_jobtitle NVARCHAR(255),
    @e_department NVARCHAR(255)

AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRY
        BEGIN TRANSACTION;

        -- Update Employee
        UPDATE [stuff].[employee] 
        SET [employee_jobtitle] = @e_jobtitle, [employee_contract] = @e_contract, [employee_department] = @e_department, [employee_startdate] = @e_startdate
        WHERE [employee].[userid] = @e_userid;

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