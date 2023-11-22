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
Use [Emp-Intranet-DB]
GO

INSERT INTO [stuff].[department]([department_name],[department_size],[department_location])
VALUES
  ('Marketing',21,'Parys'),
  ('Sales',5,'Secunda'),
  ('HR',15,'Polokwane'),
  ('Accounting',18,'Bethlehem');
GO