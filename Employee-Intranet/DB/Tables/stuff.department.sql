CREATE TABLE [stuff].[department]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [department_name] VARCHAR(50) NOT NULL, 
    [department_size] INT NOT NULL, 
    [department_location] VARCHAR(50) NOT NULL, 
    [employeeid] INT NOT NULL, 
    CONSTRAINT [FK_department_Toemployee] FOREIGN KEY ([employeeid]) REFERENCES [stuff].[employee]([id])
)
