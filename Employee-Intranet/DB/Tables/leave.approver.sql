CREATE TABLE [leave].[approver]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [managementid] INT NOT NULL, 
    [leavetypeid] INT NOT NULL, 
    CONSTRAINT [FK_approver_Tomanagement] FOREIGN KEY ([managementid]) REFERENCES [stuff].[management]([id]),
    CONSTRAINT [FK_approver_Toleave] FOREIGN KEY ([leavetypeid]) REFERENCES [leave].[leave]([id])
)
