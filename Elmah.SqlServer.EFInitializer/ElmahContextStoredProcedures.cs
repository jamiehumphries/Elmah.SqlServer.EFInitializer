namespace Elmah.SqlServer.EFInitializer
{
    using System;
    using System.Data.Entity.Core.Objects;
    using System.Data.Entity.Infrastructure;
    using System.Data.SqlClient;
    using System.Threading.Tasks;

    /// <summary>
    /// This represents the <c>DbContext</c> class for ELMAH.
    /// </summary>
    public partial class ElmahContext
    {
        /// <summary>
        /// Gets the set of court actions details.
        /// </summary>
        /// <param name="application">Application name.</param>
        /// <param name="errorId">Error Id.</param>
        /// <returns>Returns the set of court actions details.</returns>
        public async virtual Task<ObjectResult<string>> GetErrorXmlAsync(string application, Guid errorId)
        {
            var applicationParam = new SqlParameter("Application", application);
            var errorIdParam = new SqlParameter("ErrorId", errorId);

            return await ((IObjectContextAdapter)this).ObjectContext.ExecuteStoreQueryAsync<string>("EXEC [ELMAH_GetErrorXml] @Application, @ErrorId", applicationParam, errorIdParam);
        }

        /// <summary>
        /// Saves the error log into the ELMAH table.
        /// </summary>
        /// <param name="error"><c>ELMAH_Error</c> object.</param>
        /// <returns>Returns the error code.</returns>
        public virtual async Task<int> LoggErrorAsync(ELMAH_Error error)
        {
            return await this.LogErrorAsync(error.ErrorId, error.Application, error.Host, error.Type, error.Source, error.Message, error.User, error.AllXml, error.StatusCode, error.TimeUtc);
        }

        /// <summary>
        /// Saves the error log into the ELMAH table.
        /// </summary>
        /// <param name="errorId">Error Id.</param>
        /// <param name="application">Application name.</param>
        /// <param name="host">Host name.</param>
        /// <param name="type">Error type.</param>
        /// <param name="source">Error source.</param>
        /// <param name="message">Error message.</param>
        /// <param name="user">User.</param>
        /// <param name="allXml">XML serialised value.</param>
        /// <param name="statusCode">Status code.</param>
        /// <param name="timeUtc"><c>DateTime</c> in UTC.</param>
        /// <returns>Returns the error code.</returns>
        public async virtual Task<int> LogErrorAsync(Guid errorId, string application, string host, string type, string source, string message, string user, string allXml, int statusCode, DateTime timeUtc)
        {
            var errorIdParam = new SqlParameter("ErrorId", errorId);
            var applicationParam = new SqlParameter("Application", application);
            var hostParam = new SqlParameter("Host", host);
            var typeParam = new SqlParameter("Type", type);
            var sourceParam = new SqlParameter("Source", source);
            var messageParam = new SqlParameter("Message", message);
            var userParam = new SqlParameter("User", user);
            var allXmlParam = new SqlParameter("AllXml", allXml);
            var statusCodeParam = new SqlParameter("StatusCode", statusCode);
            var timeUtcParam = new SqlParameter("TimeUtc", timeUtc);

            return
                await ((IObjectContextAdapter)this).ObjectContext
                                                   .ExecuteStoreCommandAsync(
                                                       "EXEC [ELMAH_LogError] @ErrorId,     @Application,     @Host,     @Type,     @Source,    @Message,      @User,     @AllXml,     @StatusCode,     @TimeUtc",
                                                                              errorIdParam, applicationParam, hostParam, typeParam, sourceParam, messageParam, userParam, allXmlParam, statusCodeParam, timeUtcParam);
        }
    }
}