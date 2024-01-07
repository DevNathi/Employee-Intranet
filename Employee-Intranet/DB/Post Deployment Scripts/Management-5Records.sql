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
USE [Emp_Intranet-DB]
GO
INSERT INTO [stuff].[manager] ([manager_startdate],[manager_contract],[manager_jobtitle],[manager_department],[userid])
VALUES
  ('Jan 22, 2020','Permanent','Marketing Manager','Marketing',10),
  ('Sep 19, 2019','Contract','IT Manager','IT',9),
  ('Apr 24, 2021','Fixed-Term','HR Manager','HR',8),
  ('Feb 16, 2020','Permanent','Sales Manager','Sales',7),
  ('Sep 6, 2020','Contract','Logistics Manager','Logistics',6);

