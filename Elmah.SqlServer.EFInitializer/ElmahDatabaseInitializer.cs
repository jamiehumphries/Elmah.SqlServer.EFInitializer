namespace Elmah.SqlServer.EFInitializer
{
    using System.Data.Entity;

    public class ElmahDatabaseInitializer : CreateDatabaseIfNotExists<ElmahContext> {}
}