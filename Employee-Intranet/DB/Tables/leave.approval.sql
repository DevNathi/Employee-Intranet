CREATE TABLE [leave].[approval]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [approval_status] NCHAR(10) NOT NULL, 
    [approval_date] DATE NOT NULL
)
