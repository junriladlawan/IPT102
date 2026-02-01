using System.Data;
using Dapper;
using SangkayIPT102Domain.Models;   

namespace AdlawanIPT102Framework.Extensions;

public static class VapeExtension
{
	public static DynamicParameters ToVapeDynamicParameters(this VapeModel model)
	{
		var p = new DynamicParameters();

		p.Add("@Id", model.VapeId, DbType.String, ParameterDirection.Input);
		p.Add("@Code", model.VapeCode, DbType.String, ParameterDirection.Input);
		p.Add("@Title", model.VapeTitle, DbType.String, ParameterDirection.Input);
		p.Add("@Credit", model.VapeCredit, DbType.Double, ParameterDirection.Input);

		return p;
	}
}
