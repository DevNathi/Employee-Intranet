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

USE [Emp_Intranet-DB]
GO
INSERT INTO [stuff].[employee] ([employee_startdate],[employee_contract],[employee_jobtitle],[employee_department],[userid])
VALUES
  ('Jan 22, 2020','Permanent','IT Technician','Marketing',1),
  ('Oct 11, 2019','Permanent','Business Analyst','Marketing',2),
  ('Mar 17, 2021','Contract','Cleaner','IT',3),
  ('Sep 19, 2019','Contract','Intern','IT',4),
  ('Jun 9, 2019','Fixed-Term','Driver','HR',5),
  ('Apr 24, 2021','Fixed-Term','Hr Payroll','HR',6),
  ('Feb 16, 2020','Permanent','IT Technician','Sales',7),
  ('Jan 14, 2019','Permanent','Business Analyst','Sales',8),
  ('May 3, 2019','Contract','Cleaner','Logistics',9),
  ('Sep 6, 2020','Contract','Intern','Logistics',10);
