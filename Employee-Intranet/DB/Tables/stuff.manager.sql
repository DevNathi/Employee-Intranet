CREATE TABLE [stuff].[manager]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
    [employeeid] INT NOT NULL, 
    CONSTRAINT [FK_management_Toemployee] FOREIGN KEY ([employeeid]) REFERENCES [stuff].[employee]([id])
)
