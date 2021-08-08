using System.Threading.Tasks;
using TaskoMask.Application.Core.Commands;
using TaskoMask.Application.Core.Helpers;
using TaskoMask.Application.Core.Queries;

namespace TaskoMask.Application.Core.Services
{
    public interface IBaseApplicationService
    {
        Task<Result<CommandResult>> SendCommandAsync<T>(T cmd) where T : BaseCommand;
        Task<Result<T>> SendQueryAsync<T>(BaseQuery<T> query);
    }
}
