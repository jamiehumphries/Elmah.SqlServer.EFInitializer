======================================================
Post-Install Actions For Elmah.SqlServer.EFInitializer
======================================================
1. Set the connection string for ElmahConnection (see the TODO in Web.config)
2. Add a call to ElmahContext.Initialize() in start-up code (e.g. in Global.asax)