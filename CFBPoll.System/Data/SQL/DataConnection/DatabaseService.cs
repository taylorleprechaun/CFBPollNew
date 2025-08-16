using CFBPoll.Utilities;
using Microsoft.Data.SqlClient;
using System.Data;

namespace CFBPoll.System.Data.SQL.DataConnection
{
    public class DatabaseService
    {
        public DatabaseService() { }

        /// <summary>
        /// Get the database connection asynchronously.
        /// </summary>
        /// <returns>The database connection.</returns>
        public async Task<IDbConnection> GetDBConnectionAsync()
        {
            var connectionString = await Task.Run(() => ConfigurationHelper.GetConnectionString());
            return new SqlConnection(connectionString);
        }
    }
}
