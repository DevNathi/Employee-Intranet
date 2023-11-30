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

INSERT INTO [user].[user]([user_email],[user_password])

VALUES
  ('test@mail.com','Password123'),
  ('non.ante@company.co','Admin123'),
  ('pharetra@company.co','Password123'),
  ('tellus.id@company.co','Password123'),
  ('adipiscing@company.co','Password123'),
  ('aliquam.arcu.aliquam@company.co','Admin123'),
  ('neque.nullam@company.co','Admin123'),
  ('taciti.sociosqu.ad@company.co','Password123'),
  ('mi@company.co','Password123'),
  ('donec.dignissim@company.co','Admin123');
  GO