USE master
GO

IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = 'TestTemplate3Db')
BEGIN
  CREATE DATABASE TestTemplate3Db;
END;
GO

USE TestTemplate3Db;
GO

IF NOT EXISTS (SELECT 1
                 FROM sys.server_principals
                WHERE [name] = N'TestTemplate3Db_Login' 
                  AND [type] IN ('C','E', 'G', 'K', 'S', 'U'))
BEGIN
    CREATE LOGIN TestTemplate3Db_Login
        WITH PASSWORD = '<DB_PASSWORD>';
END;
GO  

IF NOT EXISTS (select * from sys.database_principals where name = 'TestTemplate3Db_User')
BEGIN
    CREATE USER TestTemplate3Db_User FOR LOGIN TestTemplate3Db_Login;
END;
GO  


EXEC sp_addrolemember N'db_datareader', N'TestTemplate3Db_User';
GO

EXEC sp_addrolemember N'db_datawriter', N'TestTemplate3Db_User';
GO

EXEC sp_addrolemember N'db_ddladmin', N'TestTemplate3Db_User';
GO
