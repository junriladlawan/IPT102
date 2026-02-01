using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SangkayIPT102Domain.Commands;
using SangkayIPT102Domain.Models;
using AdlawanIPT102Framework.Extensions;
using AdlawanIPT102Repository.Interfaces;

namespace AdlawanIPT102Framework.Commands;

public class DeleteVape : IDeleteVape
{
    private readonly string _connectionName = "DefaultConnection";
    private readonly string _storedProcedureName;
    private readonly IRepository _repository;

    public DeleteVape(IRepository reposository)
    {
        _storedProcedureName = "[dbo].[DeleteCourse]";
        _repository = _repository;
    }

    public async Task<bool> ExecuteAsync(VapeModel model)
    {
        var p = model.ToVapeDynamicParameters();
        return await _repository.SaveDataAsync(_connectionName, _storedProcedureName, p);
    }
}
