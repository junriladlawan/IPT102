using SangkayIPT102Domain.Models;

namespace SangkayIPT102Domain.Commands;

public interface ICreateVape
{
    Task<bool> ExecuteAsync(VapeModel model);
}
