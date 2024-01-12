CREATE PROCEDURE [leave].[sp_CreateNewLeaveForEmployee]
    @leave_name NVARCHAR,
    @leave_startdate DATE, 
    @leave_enddate DATE, 
    @leave_reason VARCHAR(MAX), 
    @employeeid INT , 
    @managerid INT

AS
BEGIN
    SET NOCOUNT ON;
      
    BEGIN TRY
        BEGIN TRANSACTION;
        
            DECLARE @leaveId AS INT;
            INSERT INTO [leave].[leave_requests] ([leave_name],[leave_startdate],[leave_enddate],[leave_reason],[employeeid],[managerid])
            VALUES (@leave_name, @leave_startdate, @leave_enddate, @leave_reason, @employeeid, @managerid);

            SET @leaveId = SCOPE_IDENTITY();


            -- Insert into approval table using the leaveId
            INSERT INTO [leave].[approval] ([approval_status],[leaveid])
            VALUES ('Pending', @leaveId);

        COMMIT;
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0
            ROLLBACK;

        -- Log or handle the error as needed
        SET @leaveId = -1; -- Set to a default value indicating an error
    END CATCH
END;
