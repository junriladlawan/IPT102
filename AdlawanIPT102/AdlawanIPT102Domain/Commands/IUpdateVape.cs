using SangkayIPT102Domain.Models;

namespace SangkayIPT102Domain.Commands;

public interface IUpdateVape
{
    Task<bool> ExecuteAsync(VapeModel model);
}
