CREATE TABLE [leave].[type]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [type_name] VARCHAR(50) NOT NULL, 
    [type_cycle] NVARCHAR(50) NOT NULL, 
    [type_days] INT NOT NULL
)
