/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/

INSERT INTO [leave].[type] ([type_name],[type_cycle],[type_days])
VALUES
    ('Sick','Jan-Dec',30),
    ('Annual','Jan-Dec',15),
    ('Parental','Jan-Dec',20),
    ('Family','Jan-Dec',10)
