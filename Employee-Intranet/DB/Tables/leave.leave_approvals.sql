CREATE TABLE [leave].[approval]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [approval_status] NCHAR(10) NOT NULL, 
    [leaveid] INT NOT NULL, 
    CONSTRAINT [FK_approval_Toleave] FOREIGN KEY ([leaveid]) REFERENCES [leave].[leave_requests]([Id])
)
