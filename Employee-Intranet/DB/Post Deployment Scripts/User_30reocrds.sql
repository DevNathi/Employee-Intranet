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

INSERT INTO [user].[user]([user_username],[user_email],[user_password])

VALUES
  ('dolor.egestas@company.co','vehicula.et@company.co','Password123'),
  ('quis.tristique@company.co','non.ante@company.co','Admin123'),
  ('suspendisse@company.co','pharetra@company.co','Password123'),
  ('arcu@company.co','tellus.id@company.co','Password123'),
  ('gravida.aliquam.tincidunt@company.co','adipiscing@company.co','Password123'),
  ('ipsum.dolor@company.co','aliquam.arcu.aliquam@company.co','Admin123'),
  ('arcu.vestibulum.ante@company.co','neque.nullam@company.co','Admin123'),
  ('dignissim.tempor.arcu@company.co','taciti.sociosqu.ad@company.co','Password123'),
  ('ultrices.vivamus.rhoncus@company.co','mi@company.co','Password123'),
  ('ullamcorper.nisl@company.co','donec.dignissim@company.co','Admin123');

INSERT INTO [user].[user]([user_username],[user_email],[user_password])
VALUES
  ('dui.lectus.rutrum@company.co','ipsum@company.co','Admin123'),
  ('vulputate.nisi@company.co','ut.nec.urna@company.co','Test123'),
  ('nec.mauris@company.co','faucibus@company.co','Admin123'),
  ('arcu@company.co','eget@company.co','Password123'),
  ('pellentesque.habitant.morbi@company.co','adipiscing.enim@company.co','Password123'),
  ('purus.duis.elementum@company.co','commodo@company.co','Test123'),
  ('condimentum.eget@company.co','mauris.aliquam@company.co','Password123'),
  ('ipsum.nunc@company.co','magna.tellus@company.co','Admin123'),
  ('metus.facilisis.lorem@company.co','dictum.sapien@company.co','Admin123'),
  ('ipsum.dolor@company.co','odio@company.co','Admin123');

INSERT INTO [user].[user]([user_username],[user_email],[user_password])
VALUES
  ('duis.volutpat@company.co','ante.nunc@company.co','Admin123'),
  ('gravida.praesent.eu@company.co','donec.tempor@company.co','Password123'),
  ('in.lorem@company.co','etiam.laoreet.libero@company.co','Password123'),
  ('lectus.cum.sociis@company.co','mauris@company.co','Password123'),
  ('molestie.in.tempus@company.co','lectus.a@company.co','Test123'),
  ('elit.aliquam@company.co','et.malesuada@company.co','Password123'),
  ('quis.urna@company.co','lacus@company.co','Password123'),
  ('lectus@company.co','vitae.aliquet@company.co','Password123'),
  ('integer@company.co','sed.sem@company.co','Test123'),
  ('eget@company.co','sit.amet@company.co','Test123');
  GO