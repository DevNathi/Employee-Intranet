CREATE TABLE [stuff].[employee]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [employee_startdate] DATE NOT NULL, 
    [employee_contract] VARCHAR(50) NOT NULL, 
    [employee_jobtitle] NVARCHAR(50) NOT NULL, 
    [userid] INT NOT NULL, 
    CONSTRAINT [FK_employee_Touser] FOREIGN KEY ([userid]) REFERENCES [user].[user]([id])
)
