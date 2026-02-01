using System.Data;
using Dapper;
using AdlawanIPT102Repository.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace AdlawanIPT102Repository;

public class Repository : IRepository
{
    private readonly IConfiguration _configuration;

    public Repository(IConfiguration congfiguration)
    {
        _configuration = congfiguration;
    }

    public async Task<IEnumerable<T>> GetDataAsync<T>(string connectionName, 
        string storedProcName,
        DynamicParameters parameters = null)
    {
        IEnumerable<T> q;
        
        var connectionString = _configuration.GetConnectionString(connectionName);
        using var connection = new SqlConnection(connectionString);
        if (parameters is not null) q = await connection.QueryAsync<T>(storedProcName, 
            param: parameters, 
            commandType: CommandType.StoredProcedure);
        else q = await connection.QueryAsync<T>(storedProcName, 
            commandType: CommandType.StoredProcedure);

        return q;
    }

    public async Task<bool> SaveDataAsync(string connectionName, 
        string storedProcName,
        DynamicParameters parameters = null)
    {
        int i = 0;

        var connectionString = _configuration.GetConnectionString(connectionName);
        using var connection = new SqlConnection(connectionString);
        
        if (parameters is not null) i = await connection.ExecuteAsync(storedProcName, 
            param: parameters, 
            commandType: CommandType.StoredProcedure);
        else i = await connection.ExecuteAsync(storedProcName, 
            commandType: CommandType.StoredProcedure);

        return i == 0;
    }
}
