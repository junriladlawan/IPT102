using SangkayIPT102Domain.Models;

namespace SangkayIPT102Domain.Commands;

public interface IDeleteVape
{
    Task<bool> ExecuteAsync(VapeModel model);
}
