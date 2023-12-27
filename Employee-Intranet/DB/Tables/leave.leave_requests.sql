CREATE TABLE [leave].[leave_requests]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [leave_startdate] DATE NOT NULL, 
    [leave_enddate] DATE NOT NULL, 
    [leave_reason] VARCHAR(50) NOT NULL, 
    [leave_name] VARCHAR(50) NOT NULL, 
    [employeeid] INT NOT NULL, 
    [managerid] INT NOT NULL, 
    CONSTRAINT [FK_leave_Toemployee] FOREIGN KEY ([employeeid]) REFERENCES [stuff].[employee]([id]), 
    CONSTRAINT [FK_leave_Tomanager] FOREIGN KEY ([managerid]) REFERENCES [stuff].[manager]([Id])
)
