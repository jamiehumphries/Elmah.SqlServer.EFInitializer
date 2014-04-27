namespace Elmah.SqlServer.EFInitializer.Migrations
{
    using System.Data.Entity.Migrations;

    public sealed class ElmahConfiguration : DbMigrationsConfiguration<ElmahContext>
    {
        public ElmahConfiguration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "Elmah.SqlServer.EFInitializer.ElmahContext";
        }

        protected override void Seed(ElmahContext context) {}
    }
}