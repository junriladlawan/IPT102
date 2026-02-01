using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SangkayIPT102Domain.Models;
using IPT102Framework.Extensions;
using AdlawanIPT102Repository.Interfaces;

namespace IPT102Framework.Queries;

public class GetVapeById
{
    private readonly string _connectionName;
    private readonly string _storedProcedureName;
    private readonly IRepository _repository;

    public GetVapeById(IRepository repository)
    {
        _connectionName = "DefaultConnection";
        _storedProcedureName = "[dbo].[GetCourseById]";
        _repository = repository;
    }

    public async Task<VapeModel?> ExecuteAsync(string id)
    {
        var parameters = id.ToDynamicParameters("Id");
        var result = await _repository.GetDataAsync<VapeModel>(_connectionName, _storedProcedureName, parameters);

        return result.FirstOrDefault();
    }
}
