Elmah.SqlServer.EFInitializer
=============================

[![Build status](https://ci.appveyor.com/api/projects/status/1jbpq86t19ok1r2n/branch/master?svg=true)](https://ci.appveyor.com/project/jamiehumphries/elmah-sqlserver-efinitializer/branch/master)

Automatically creates an Elmah database on SQL Server using Entity Framework migrations.

#### Installation

This project is available as a [NuGet package](https://www.nuget.org/packages/Elmah.SqlServer.EFInitializer/).
It can be installed from the Visual Studio Package Manager Console using `Install-Package Elmah.SqlServer.EFInitializer`.

#### Configuration

By default the database will be created using the `DefaultConnection` connection string.

If you wish to use a different connection string, you should declare a named string in the `connectionStrings` section of `Web.config` and edit the `connectionStringName` attribute on the `elmah / errorLog` configuration element. For example:

```xml
<configuration>
  <!-- Other configuration omitted -->
  <connectionStrings>
    <add name="ElmahConnection"
         connectionString="Data Source=(local);Initial Catalog=Elmah;Integrated Security=True;"
         providerName="System.Data.SqlClient" />
  </connectionStrings>
  <elmah>
    <errorLog type="Elmah.SqlErrorLog, Elmah" 
              connectionStringName="ElmahConnection" />
  </elmah>
</configuration>
```

#### Usage note

The intent of this package is _only_ to automate the creation of a backing SQL Server database for Elmah and provide enough configuration to do the basic logging. Errors will be logged to the database, but you will also need to install something like the main [Elmah](https://www.nuget.org/packages/elmah/) package or [Elmah.MVC](https://www.nuget.org/packages/Elmah.MVC/) to view them within the site.

#### Acknowledgements

Credit must go to the creators of [Elmah.SqlServer](https://www.nuget.org/packages/elmah.sqlserver/1.2.0), the SQL from that project is what I used for the migrations.
