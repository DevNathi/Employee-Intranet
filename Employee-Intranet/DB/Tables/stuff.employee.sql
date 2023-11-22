CREATE TABLE [stuff].[employee]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [employee_startdate] DATE NOT NULL, 
    [employee_contract] VARCHAR(50) NOT NULL, 
    [employee_jobtitle] NVARCHAR(50) NOT NULL, 
    [userid] INT NOT NULL, 
    [permissionid] INT NOT NULL, 
    [departmentid] INT NOT NULL, 
    CONSTRAINT [FK_employee_Touser] FOREIGN KEY ([userid]) REFERENCES [user].[user]([id]),
      CONSTRAINT [FK_employee_Topermission] FOREIGN KEY ([permissionid]) REFERENCES [stuff].[permissions]([id]), 
    CONSTRAINT [FK_employee_ToDepartment] FOREIGN KEY ([departmentid]) REFERENCES [stuff].[department]([id])
)
