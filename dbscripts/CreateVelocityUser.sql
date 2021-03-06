USE [master]
GO
CREATE LOGIN [VelocityUser] WITH PASSWORD=N'pwd', DEFAULT_DATABASE=[Velocity], CHECK_EXPIRATION=OFF, CHECK_POLICY=OFF
GO
USE [Velocity]
GO
CREATE USER [VelocityUser] FOR LOGIN [VelocityUser]
GO
USE [Velocity]
GO
ALTER ROLE [db_owner] ADD MEMBER [VelocityUser]
GO
