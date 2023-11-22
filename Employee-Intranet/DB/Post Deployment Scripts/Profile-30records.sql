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
Use [Emp_Intranet-DB]
GO

INSERT INTO [user].[profile] ([profile_title],[profile_name],[profile_surname],[user], [role])
VALUES
    ('Ms.','Luke','Silva',1,2),
  ('Dr.','Kaseem','Carr',2,2),
  ('Mr.','Ursula','Crosby',3,2),
  ('Dr.','Idona','Buchanan',4,2),
  ('Mrs.','Jordan','Hurst',5,3),
  ('Dr.','Illana','Floyd',6,2),
  ('Ms.','Fiona','Yates',7,1),
  ('Dr.','Ifeoma','Chandler',8,2),
  ('Dr.','James','Sexton',9,2),
  ('Ms.','Aretha','Bartlett',10,2);
INSERT INTO [user].[profile] ([profile_title],[profile_name],[profile_surname],[user], [role])
VALUES
  ('Dr.','Tamara','Hutchinson',11,2),
  ('Mr.','Hope','Wiley',12,3),
  ('Dr.','Kylynn','Strong',13,3),
  ('Dr.','Walter','Maldonado',14,1),
  ('Ms.','Nelle','Alston',15,2),
  ('Ms.','Aline','Mitchell',16,1),
  ('Mrs.','Lara','Britt',17,3),
  ('Mr.','Francis','Slater',18,3),
  ('Dr.','Inga','Newman',19,2),
  ('Dr.','Paloma','Carson',20,2);
INSERT INTO [user].[profile] ([profile_title],[profile_name],[profile_surname],[user], [role])
VALUES
  ('Ms.','Kristen','Cole',21,2),
  ('Mrs.','Dean','Pugh',22,2),
  ('Mr.','Denton','Pitts',23,1),
  ('Ms.','May','Butler',24,2),
  ('Ms.','Linda','Clay',25,2),
  ('Mr.','Hyatt','Hurst',26,2),
  ('Mr.','Chantale','Watkins',27,2),
  ('Dr.','Yolanda','Bowers',28,1),
  ('Dr.','Kennedy','Keller',29,3),
  ('Dr.','Cally','Paul',30,1);
GO