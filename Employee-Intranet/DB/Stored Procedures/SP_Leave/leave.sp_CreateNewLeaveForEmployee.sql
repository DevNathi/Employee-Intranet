CREATE PROCEDURE [leave].[sp_CreateNewLeaveForEmployee]
    @leave_startdate DATE, 
    @leave_enddate DATE, 
    @leave_reason VARCHAR(MAX), 
    @leave_comment VARCHAR(MAX), 
    @employeeid INT , 
    @approverid INT, 
    @leavetypeid INT,
    @returnValue INT OUTPUT
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRY
        BEGIN TRANSACTION;

        INSERT INTO [leave].[leave] ([employeeid], [leave_startdate], [leave_enddate], [leave_reason], [leavetypeid], [leave_comment], [approverid])
        VALUES (@employeeid, @leave_startdate, @leave_enddate, @leave_reason, @leavetypeid, @leave_comment, @approverid);

        COMMIT;
        SET @returnValue = 0; -- Success
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0
            ROLLBACK;

        -- Log or handle the error as needed
        SET @returnValue = ERROR_NUMBER();
    END CATCH
END;
