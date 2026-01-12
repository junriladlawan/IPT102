using Dapper;
using Microsoft.Data.SqlClient;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public abstract class BaseRepository<T> : IBaseRepository<T>
    {
        private readonly string _dbConnection;

        protected BaseRepository(string dbConnection)
        {
            _dbConnection = dbConnection;
        }

        protected IDbConnection OpenConnection()
        {
            return new SqlConnection(_dbConnection);
        }

        public async Task<IEnumerable<T>> GetListAsync(
            string procedure,
            DynamicParameters? parameters = null,
            CancellationToken cancellationToken = default)
        {
            using var connection = OpenConnection();

            return await connection.QueryAsync<T>(
                procedure,
                parameters,
                commandType: CommandType.StoredProcedure);
        }

        public async Task<T?> GetSingleAsync(
            string procedure,
            DynamicParameters? parameters = null,
            CancellationToken cancellationToken = default)
        {
            using var connection = OpenConnection();

            return await connection.QueryFirstOrDefaultAsync<T>(
                procedure,
                parameters,
                commandType: CommandType.StoredProcedure);
        }

        public async Task<int> SaveAsync(
            string procedure,
            DynamicParameters? parameters = null,
            CancellationToken cancellationToken = default)
        {
            using var connection = OpenConnection();

            return await connection.ExecuteAsync(
                procedure,
                parameters,
                commandType: CommandType.StoredProcedure);
        }
    }
}
