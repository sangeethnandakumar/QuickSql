
using Dapper;
using Microsoft.Data.SqlClient;

public class SqlHelper
{
    private static readonly Lazy<SqlConnection> _sharedConnection = new Lazy<SqlConnection>(() =>
    {
        var connection = new SqlConnection("<DEFAULT_CONN_STRING>");
        connection.Open();
        return connection;
    });

    public static SqlResult RunSQL(string connectionString, string query, params object[] parameters)
    {
        using (var connection = new SqlConnection(connectionString))
        {
            connection.Open();

            if (parameters == null || parameters.Length == 0)
            {
                // Execute the query without parameters
                var result = connection.Query(query);
                return new SqlResult(result);
            }
            else
            {
                // Execute the query with parameters
                var result = connection.Query(query, parameters);
                return new SqlResult(result);
            }

        }
    }

    public static SqlResult RunSQL(string query, params object[] parameters)
    {
        return RunSQL(_sharedConnection.Value.ConnectionString, query, parameters);
    }
}
