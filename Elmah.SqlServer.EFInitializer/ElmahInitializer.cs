namespace Elmah.SqlServer.EFInitializer
{
    using Elmah.SqlServer.EFInitializer.Migrations;
    using System.Data.Entity;

    public class ElmahInitializer : MigrateDatabaseToLatestVersion<ElmahContext, ElmahConfiguration> {}
}