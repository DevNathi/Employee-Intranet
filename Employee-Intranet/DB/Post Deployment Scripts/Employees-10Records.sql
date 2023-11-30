/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/
--IF EXISTS(SELECT 1 FROM sys.tables WHERE object_id = OBJECT_ID('Employee'))
--BEGIN;
--    DROP TABLE [Employee];
--END;
--GO

--CREATE TABLE [Employee] (
--    [EmployeeID] INTEGER NOT NULL IDENTITY(1, 1),
--    [employee_jobtitle] VARCHAR(MAX) NULL,
--    [employee_startdate] VARCHAR(255) NULL,
--    [userid] INTEGER NULL,
--    [permissionid] INTEGER NULL,
--    [departmentid] INTEGER NULL,
--    [employee_contract] VARCHAR(MAX) NULL,
--    PRIMARY KEY ([EmployeeID])
--);
--GO

INSERT INTO [stuff].[employee] (employee_jobtitle,employee_contract,employee_startdate,userid,permissionid,departmentid)
VALUES
  ('Developer','Permanent','4/50/2023',1,1,1),
  ('Analyst','Contract','1/57/2024',2,2,2),
  ('Driver','Permanent','6/30/2024',3,3,3),
  ('Security','Contract','26/49/2024',4,4,4),
  ('Cleaner','Permanent','8/33/2024',5,5,5),
  ('Developer','Contract','26/29/2023',6,6,6),
  ('Analyst','Permanent','20/13/2024',7,7,7),
  ('Driver','Contract','10/3/2024',8,8,8),
  ('Security','Permanent','20/29/2023',9,9,9),
  ('Cleaner','Contract','25/49/2023',10,10,10);