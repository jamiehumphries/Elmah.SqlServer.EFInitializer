namespace Elmah.SqlServer.EFInitializer.Migrations
{
    using System.Data.Entity.Migrations;
    using System.IO;
    using System.Reflection;

    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ELMAH_Error",
                c => new
                     {
                         ErrorId = c.Guid(false),
                         Application = c.String(false, 60),
                         Host = c.String(false, 50),
                         Type = c.String(false, 100),
                         Source = c.String(false, 60),
                         Message = c.String(false, 500),
                         User = c.String(false, 50),
                         StatusCode = c.Int(false),
                         TimeUtc = c.DateTime(false),
                         Sequence = c.Int(false, true),
                         AllXml = c.String(false, storeType: "ntext")
                     })
                .PrimaryKey(t => t.ErrorId);

            SqlFromFile("Create_ELMAH_GetErrorXml.sql");
            SqlFromFile("Create_ELMAH_GetErrorsXml.sql");
            SqlFromFile("Create_ELMAH_LogError.sql");
        }

        public override void Down()
        {
            SqlFromFile("Drop_ELMAH_Procedures.sql");
            DropTable("dbo.ELMAH_Error");
        }

        private void SqlFromFile(string sqlFileName)
        {
            var assembly = Assembly.GetExecutingAssembly();
            var stream = assembly.GetManifestResourceStream(GetType(), sqlFileName);
            if (stream == null)
            {
                throw new FileNotFoundException("Could not find the embedded resource: " + sqlFileName);
            }
            var sqlToExecute = new StreamReader(stream).ReadToEnd();
            Sql(sqlToExecute);
        }
    }
}