CREATE TABLE [user].[user]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [user_email] NVARCHAR(50) NOT NULL, 
    [user_password] NCHAR(25) NOT NULL
)
