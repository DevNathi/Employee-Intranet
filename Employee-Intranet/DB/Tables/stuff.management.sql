CREATE TABLE [stuff].[management]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [management_level] NVARCHAR(50) NOT NULL, 
    [employeeid] INT NOT NULL, 
    CONSTRAINT [FK_management_Toemployee] FOREIGN KEY ([employeeid]) REFERENCES [stuff].[employee]([id])
)
