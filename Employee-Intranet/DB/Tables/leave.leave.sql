CREATE TABLE [leave].[leave]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [leave_startdate] DATE NOT NULL, 
    [leave_enddate] DATE NOT NULL, 
    [leave_reason] VARCHAR(50) NOT NULL, 
    [leave_comment] VARCHAR(50) NOT NULL, 
    [employeeid] INT NOT NULL, 
    [permissionid] INT NOT NULL, 
    [leavetypeid] INT NOT NULL, 
    CONSTRAINT [FK_leave_Toemployee] FOREIGN KEY ([employeeid]) REFERENCES [stuff].[employee]([id]), 
    CONSTRAINT [FK_leave_Totype] FOREIGN KEY ([leavetypeid]) REFERENCES [leave].[type]([id])
)
