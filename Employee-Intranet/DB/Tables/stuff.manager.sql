CREATE TABLE [stuff].[manager]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [manager_jobtitle] NCHAR(50) NOT NULL, 
    [manager_department] NCHAR(50) NOT NULL, 
    [manager_contract] NVARCHAR(50) NOT NULL, 
    [manager_startdate] DATE NOT NULL, 
    [userid] INT NOT NULL, 
    CONSTRAINT [FK_manager_ToUser] FOREIGN KEY ([userId]) REFERENCES [user].[user]([Id]) 
)
