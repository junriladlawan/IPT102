using System;
using AdlawanIPT102Repository.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace AdlawanIPT102Repository.Interfaces;

public interface IRepository
{
    public Task<IEnumerable<T>> GetDataAsync<T>(string connectionString, 
        string storedProcName, 
        DynamicParameters parameters = null);
    public Task<bool> SaveDataAsync(string connectionString, 
        string storedProcName, 
        DynamicParameters parameters = null);
}
