CREATE TABLE [stuff].[permissions]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [permission_type] NCHAR(10) NOT NULL, 
    [permission_name] NCHAR(10) NOT NULL, 
    [employeeid] INT NOT NULL
  
)
