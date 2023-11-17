CREATE TABLE [user].[user]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [user_username] NVARCHAR(50) NOT NULL, 
    [user_email] NVARCHAR(50) NOT NULL, 
    [user_password] NCHAR(25) NOT NULL
)
