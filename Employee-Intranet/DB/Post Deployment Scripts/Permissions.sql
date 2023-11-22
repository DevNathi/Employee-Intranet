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
USE [Emp-Intranet-DB]
GO

INSERT INTO [stuff].[permissions]([permission_name],[permission_type])
VALUES
  ('general','non-approver'),
  ('level-1','approver'),
  ('level-2','non-approver'),
  ('general','approver'),
  ('level-1','non-approver');
  GO