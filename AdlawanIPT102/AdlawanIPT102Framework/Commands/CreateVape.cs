using SangkayIPT102Domain.Commands;
using SangkayIPT102Domain.Models;         
using AdlawanIPT102Framework.Extensions;
using AdlawanIPT102Repository;
using AdlawanIPT102Repository.Interfaces;
using System.Threading.Tasks;

namespace AdlawanIPT102Framework.Commands;

public class CreateVape : ICreateVape
{
    private readonly string _connectionName = "DefaultConnection";
    private readonly string _storedProcedureName = "[dbo].[CreateSupplier]";
    private readonly IRepository _repository;

    public CreateVape(IRepository repository)
    {
        _repository = repository;
    }

    public async Task<bool> ExecuteAsync(VapeModel model)
    {
        var p = model.ToVapeDynamicParameters();
        return await _repository.SaveDataAsync(_connectionName, _storedProcedureName, p);
    }
}
