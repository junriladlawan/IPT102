using Dapper;

namespace AdlawanIPT102Framework.Commands
{
    public interface IRepository
    {
        Task<bool> SaveDataAsync(string connectionName, string storedProcedureName, DynamicParameters p);
    }
}