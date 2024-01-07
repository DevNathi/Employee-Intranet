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

INSERT INTO [user].[profile] ([profile_title],[profile_name],[profile_surname],[user])
VALUES
  ('Mr','Lee','Patel',1),
  ('Mr','Lillith','Nunez',2),
  ('Mrs','Ivana','Lang',3),
  ('Mrs','Kyla','Compton',4),
  ('Miss','Hall','Bond',5),
  ('Miss','Octavius','Frye',6),
  ('Dr','Mannix','Cardenas',7),
  ('Dr','Leandra','Dyer',8),
  ('Mr','Jakeem','Kent',9),
  ('Mr','Arthur','Richmond',10);
INSERT INTO [user].[profile] ([profile_title],[profile_name],[profile_surname],[user])
VALUES
  ('Mrs','Brody','Holmes',11),
  ('Mrs','Byron','Clark',12),
  ('Miss','Nell','Sears',13),
  ('Miss','Bernard','Barnes',14),
  ('Dr','Merritt','Stuart',15),
  ('Dr','Hamish','Mcleod',16),
  ('Mr','Madonna','Estrada',17),
  ('Mr','Ann','Higgins',18),
  ('Mrs','Dai','Boyer',19),
  ('Mrs','Herman','Melendez',20);
INSERT INTO [user].[profile] ([profile_title],[profile_name],[profile_surname],[user])
VALUES
  ('Miss','Clayton','Maldonado',21),
  ('Miss','Autumn','Nolan',22),
  ('Dr','Silas','Durham',23),
  ('Dr','Latifah','Haley',24),
  ('Mr','Brady','Ballard',25),
  ('Mr','Sylvester','Bolton',26),
  ('Mrs','Peter','Phillips',27),
  ('Mrs','Nissim','Madden',28),
  ('Miss','Burton','Pruitt',29),
  ('Miss','Veda','Osborn',30);
GO