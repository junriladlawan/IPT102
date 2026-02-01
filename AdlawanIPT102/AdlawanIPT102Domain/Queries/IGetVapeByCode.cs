using SangkayIPT102Domain.Models;

namespace SangkayIPT102Domain.Queries;

public interface IGetVapeByCode
{
    Task<VapeModel?> ExecuteAsync(string code);
}
