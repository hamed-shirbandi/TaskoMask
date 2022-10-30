using System.Threading.Tasks;
using TaskoMask.BuildingBlocks.Application.Commands;
using TaskoMask.BuildingBlocks.Application.Queries;
using TaskoMask.BuildingBlocks.Contracts.Helpers;
using TaskoMask.BuildingBlocks.Domain.Models;

namespace TaskoMask.BuildingBlocks.Application.Bus
{
    /// <summary>
    /// It is used as a mediator to send and handle requests inside a single service
    /// </summary>
    public interface IInMemoryBus
    {
        Task<Result<CommandResult>> SendCommand<TCommand>(TCommand cmd) where TCommand : BaseCommand;
        Task<Result<TQueryResult>> SendQuery<TQueryResult>(BaseQuery<TQueryResult> query);
        Task PublishEvent(DomainEvent @event);
    }
}
