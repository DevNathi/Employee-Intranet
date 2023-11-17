CREATE TABLE [user].[profile]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [profile_title] NCHAR(10) NOT NULL, 
    [profile_name] NVARCHAR(50) NOT NULL, 
    [profile_surname] NVARCHAR(50) NOT NULL
)
