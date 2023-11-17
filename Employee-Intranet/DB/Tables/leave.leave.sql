CREATE TABLE [leave].[leave]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [leave_startdate] DATE NOT NULL, 
    [leave_enddate] DATE NOT NULL, 
    [leave_reason] VARCHAR(50) NOT NULL, 
    [leave_comment] VARCHAR(50) NOT NULL
)
