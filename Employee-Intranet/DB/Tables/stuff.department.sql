﻿CREATE TABLE [stuff].[department]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [department_name] VARCHAR(50) NOT NULL, 
    [department_size] INT NOT NULL, 
    [department_location] VARCHAR(50) NOT NULL, 
    [department_manager] NVARCHAR(50) NOT NULL
)
