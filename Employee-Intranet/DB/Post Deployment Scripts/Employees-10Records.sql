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
--    [departmentid] INTEGER NULL,
--    [employee_contract] VARCHAR(MAX) NULL,
--    PRIMARY KEY ([EmployeeID])
--);
--GO


INSERT INTO [stuff].[employee] (employee_jobtitle,employee_contract,employee_startdate,userid,departmentid)
VALUES
  ('Developer','Permanent','04-03-2023',1,1),
  ('Analyst','Contract','04-03-2023',2,2),
  ('Driver','Permanent','04-03-2023',3,3),
  ('Security','Contract','04-03-2023',4,4),
  ('Cleaner','Permanent','04-03-2023',5,1),
  ('Developer','Contract','04-03-2023',6,2),
  ('Analyst','Permanent','04-03-2023',7,3),
  ('Driver','Contract','04-03-2023',8,4),
  ('Security','Permanent','04-03-2023',9,3),
  ('Cleaner','Contract','04-03-2023',10,1);