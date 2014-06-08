Elmah.SqlServer.EFInitializer
=============================

**_This project is very young! Please do raise any issues that you find and I will try and resolve them._**

Automatically creates an Elmah database on SQL Server using Entity Framework migrations.

By default the database will be created using the `DefaultConnection` connection string.

If you wish to use a different connection string, you should declare a named string in the `connectionStrings` section of `Web.config` and edit the `connectionStringName` attribute on the `elmah / errorLog` configuration element. For example:

```xml
<configuration>
  <!-- Other configuration omitted -->
  <connectionStrings>
    <add name="MyElmahConnection"
         connectionString="Data Source=(local);Initial Catalog=MyElmah;Integrated Security=True;"
         providerName="System.Data.SqlClient" />
  </connectionStrings>
  <elmah>
    <errorLog type="Elmah.SqlErrorLog, Elmah" connectionStringName="MyElmahConnection" />
  </elmah>
</configuration>
```

**_NOTE!_**

The intent of this package is _only_ to automate the creation of a backing SQL Server database for Elmah and provide enough configuration to do the basic logging. Errors will be logged to the database, but you will also need to install something like the main [Elmah](https://www.nuget.org/packages/elmah/) package or [Elmah.MVC](https://www.nuget.org/packages/Elmah.MVC/) to view them within the site.

Credit must go to the creators of [Elmah.SqlServer](https://www.nuget.org/packages/elmah.sqlserver/1.2.0), the SQL from that project is what I used for the migrations.
