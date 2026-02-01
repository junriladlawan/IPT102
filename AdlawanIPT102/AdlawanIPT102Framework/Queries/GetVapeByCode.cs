using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using SangkayIPT102Domain.Models;
using SangkayIPT102Domain.Queries;
using IPT102Framework.Extensions;
using AdlawanIPT102Repository.Interfaces;

namespace AdlawanIPT102Framework.Queries;

public class GetVapeByCode : IGetVapeByCode
{
    private readonly string _connectionName = "DefaultConnection";
    private readonly string _storeProcedureName;
    private readonly IRepository _repository;

    public GetVapeByCode(IRepository repository)
    {
        _storeProcedureName = "[dbo].[GetCourseByCode]";
        _repository = repository;
    }

    public async Task<VapeModel?> ExecuteAsync(string code)
    {
        var parameters = code.ToDynamicParameters("Code");
        var data = await _repository.GetDataAsync<VapeModel>(_connectionName, _storeProcedureName, parameters);

        return data.FirstOrDefault();
    }
}
