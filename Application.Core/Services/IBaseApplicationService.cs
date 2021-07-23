using CSharpFunctionalExtensions;
using MediatR;
using System.Threading.Tasks;
using TaskoMask.Application.Core.Commands;

namespace TaskoMask.Application.Core.Services
{
    public interface IBaseApplicationService
    {
        Task<Result<CommandResult>> RunCommandAsync<T>(T cmd) where T : BaseCommand;
        Task<Result<U>> RunQueryAsync<T, U>(T query) where T : IBaseRequest;
    }
}