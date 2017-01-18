EXECUTE sp_addrolemember @rolename = N'db_securityadmin', @membername = N'IIS APPPOOL\mysite';


GO
EXECUTE sp_addrolemember @rolename = N'db_owner', @membername = N'IIS APPPOOL\mysite';


GO
EXECUTE sp_addrolemember @rolename = N'db_denydatawriter', @membername = N'IIS APPPOOL\mysite';


GO
EXECUTE sp_addrolemember @rolename = N'db_denydatareader', @membername = N'IIS APPPOOL\mysite';


GO
EXECUTE sp_addrolemember @rolename = N'db_ddladmin', @membername = N'IIS APPPOOL\mysite';


GO
EXECUTE sp_addrolemember @rolename = N'db_datawriter', @membername = N'IIS APPPOOL\mysite';


GO
EXECUTE sp_addrolemember @rolename = N'db_datareader', @membername = N'IIS APPPOOL\mysite';


GO
EXECUTE sp_addrolemember @rolename = N'db_backupoperator', @membername = N'IIS APPPOOL\mysite';


GO
EXECUTE sp_addrolemember @rolename = N'db_accessadmin', @membername = N'IIS APPPOOL\mysite';

