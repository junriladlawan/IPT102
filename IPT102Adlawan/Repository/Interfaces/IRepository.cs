using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface IBaseRepository<T>
    {
        Task<IEnumerable<T>> GetListAsync(
            string procedure,
            DynamicParameters? parameters = null,
            CancellationToken cancellationToken = default);

        Task<T?> GetSingleAsync(
            string procedure,
            DynamicParameters? parameters = null,
            CancellationToken cancellationToken = default);

        Task<int> SaveAsync(
            string procedure,
            DynamicParameters? parameters = null,
            CancellationToken cancellationToken = default);
    }
}
