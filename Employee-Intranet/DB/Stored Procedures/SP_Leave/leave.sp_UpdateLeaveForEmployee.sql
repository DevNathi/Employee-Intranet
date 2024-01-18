CREATE PROCEDURE [leave].[sp_UpdateLeaveForEmployee]
    @Id Int,
    @leave_name NVARCHAR(MAX),
    @leave_startdate DATE, 
    @leave_enddate DATE, 
    @leave_reason VARCHAR(MAX), 
    @employeeid INT , 
    @managerid INT
AS
BEGIN
    SET NOCOUNT ON;

    -- Check if the leave record exists
    IF EXISTS (SELECT 1 FROM [leave].[leave_requests] WHERE Id = @Id)
    BEGIN
        -- Update leave information
        UPDATE [leave].[leave_requests]
        SET
            leave_name = @leave_name,
            leave_reason = @leave_reason,
            leave_startdate = @leave_startdate,
            leave_enddate = @leave_enddate
        WHERE
            Id = @Id;

        SELECT 'Leave record updated successfully.' AS Result;
    END
    ELSE
    BEGIN
        
        SELECT 'Leave record with ID ' + CAST(@Id AS VARCHAR) + ' not found.' AS Result;
    END
END;