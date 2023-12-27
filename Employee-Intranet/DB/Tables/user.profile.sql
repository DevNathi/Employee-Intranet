CREATE TABLE [user].[profile]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [profile_title] NCHAR(10) NOT NULL, 
    [profile_name] NVARCHAR(50) NOT NULL, 
    [profile_surname] NVARCHAR(50) NOT NULL, 
    [user] INT NOT NULL, 
    CONSTRAINT [FK_profile_Touser] FOREIGN KEY ([user]) REFERENCES [user].[user]([id])
   
)
