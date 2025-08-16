using CFBPoll.System.Data.SQL.DataConnection;
using Dapper;
using System.Data;

namespace WPU.InsurSys.Framework.Data.SQL.DataConnection;

public class DapperExecutor
{
    private readonly DatabaseService _databaseService;

    public DapperExecutor()
    {
        _databaseService = new DatabaseService();
    }

    #region public methods

    /// <summary>
    /// Executes a SQL command asynchronously and returns and int result.
    /// </summary>
    /// <param name="sql">The command to execute.</param>
    /// <param name="param">The command parameters.</param>
    /// <returns>An int representing an error code, an ID returned from the SQL, or the number of rows affected.</returns>
    public async Task<int> ExecuteAsync(string sql, object? param = null)
    {
        using var connection = await CreateConnectionAsync();
        return await connection.ExecuteAsync(sql, param);
    }

    /// <summary>
    /// Executes a SQL stored procedure asynchronously and returns a collection of results.
    /// </summary>
    /// <typeparam name="T">The return data type.</typeparam>
    /// <param name="spName">The name of the stored procedure to execute.</param>
    /// <param name="param">The stored procedure parameters.</param>
    /// <returns>A collection of the given data type.</returns>
    public async Task<IEnumerable<T>> ExecuteStoredProcedureAsync<T>(string spName, object? param = null)
    {
        try
        {
            using var connection = await CreateConnectionAsync();
            return await connection.QueryAsync<T>(spName, param, commandType: CommandType.StoredProcedure);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    /// <summary>
    /// Executes a SQL query asynchronously and returns a collection of results.
    /// </summary>
    /// <typeparam name="T">The return data type.</typeparam>
    /// <param name="sql">The command to execute.</param>
    /// <param name="param">The stored procedure parameters.</param>
    /// <returns>A collection of the given data type.</returns>
    public async Task<IEnumerable<T>> QueryAsync<T>(string sql, object? param = null)
    {
        using var connection = await CreateConnectionAsync();

        return await connection.QueryAsync<T>(sql, param);
    }

    #endregion

    #region private methods

    /// <summary>
    /// Get the database connection asynchronously.
    /// </summary>
    /// <returns>The database connection.</returns>
    private async Task<IDbConnection> CreateConnectionAsync()
    {
        return await _databaseService.GetDBConnectionAsync();
    }

    #endregion
}