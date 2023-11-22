CREATE TABLE [leave].[approval]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [approval_status] NCHAR(10) NOT NULL, 
    [approval_date] DATE NOT NULL, 
    [approverid] INT NOT NULL, 
    [leaveid] INT NOT NULL, 
    CONSTRAINT [FK_approval_Toapprover] FOREIGN KEY ([approverid]) REFERENCES [leave].[approver]([id]),
    CONSTRAINT [FK_approval_Toleave] FOREIGN KEY ([leaveid]) REFERENCES [leave].[leave]([id])
)
