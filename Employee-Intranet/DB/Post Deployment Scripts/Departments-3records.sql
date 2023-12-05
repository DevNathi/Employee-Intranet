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
INSERT INTO [stuff].[department]([department_name],[department_size],[department_location],[department_manager])
VALUES
  ('Marketing',21,'Parys','John Doe'),
  ('Sales',5,'Secunda','Jane Doey'),
  ('HR',15,'Polokwane','Man of the Match'),
  ('Accounting',18,'Bethlehem', 'Jack Sparow');
GO