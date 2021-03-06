
USE [test]
GO
DROP USER [TitanReportUser] 
GO

USE [master]
GO
DROP LOGIN TitanReportUser
GO

sqlcmd -S .\Titan -U sa -P Password1

CREATE LOGIN [TitanReportUser] WITH PASSWORD=N'pwd', DEFAULT_DATABASE=[test], CHECK_EXPIRATION=OFF, CHECK_POLICY=OFF
GO

CREATE LOGIN [TitanReportUser] WITH PASSWORD=N'pwd', DEFAULT_DATABASE=master, CHECK_EXPIRATION=OFF, CHECK_POLICY=OFF
GO

USE [test]
GO
CREATE USER [TitanReportUser] FOR LOGIN [TitanReportUser]
GO
ALTER ROLE [db_owner] ADD MEMBER [TitanReportUser]
GO
