using $rootnamespace$;
using WebActivatorEx;

[assembly: PreApplicationStartMethod(typeof(ElmahInitializer), "Initialize")]

namespace $rootnamespace$
{
    using Elmah.SqlServer.EFInitializer;
    using System.Collections;
    using System.Configuration;

    public static class ElmahInitializer
    {
        public static void Initialize()
        {
            var errorLogSection = ConfigurationManager.GetSection("elmah/errorLog") as IDictionary;

            if (errorLogSection == null)
            {
                throw new ConfigurationErrorsException("The elmah/errorLog section in web.config is missing.");
            }

            if (!errorLogSection.Contains("connectionStringName"))
            {
                throw new ConfigurationErrorsException("The elmah/errorLog section in web.config is missing the \"connectionStringName\" property");
            }

            var connectionStringName = errorLogSection["connectionStringName"].ToString();
            using (var context = new ElmahContext(connectionStringName))
            {
                context.Database.Initialize(true);
            }
        }
    }
}