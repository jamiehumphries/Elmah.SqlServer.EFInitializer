namespace Elmah.SqlServer.EFInitializer
{
    using System.Data.Entity;

    public class ElmahInitializer : CreateDatabaseIfNotExists<ElmahContext> {}
}