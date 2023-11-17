CREATE TABLE [user].[roles]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [role_name] NCHAR(10) NOT NULL, 
    [profileid] INT NOT NULL, 
    CONSTRAINT [FK_roles_Toprofile] FOREIGN KEY ([profileid]) REFERENCES [user].[profile]([id])
)
