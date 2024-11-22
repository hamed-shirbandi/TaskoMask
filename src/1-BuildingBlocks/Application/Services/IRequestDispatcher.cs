using System.Threading.Tasks;
using TaskoMask.BuildingBlocks.Application.Commands;
using TaskoMask.BuildingBlocks.Application.Queries;
using TaskoMask.BuildingBlocks.Contracts.Helpers;
using TaskoMask.BuildingBlocks.Domain.Events;

namespace TaskoMask.BuildingBlocks.Application.Services;

/// <summary>
/// Dispatches commands, queries, and domain events within the application (in-process).
/// </summary>
public interface IRequestDispatcher
{
    Task<Result<CommandResult>> SendCommand<TCommand>(TCommand cmd)
        where TCommand : BaseCommand;
    Task<Result<TQueryResult>> SendQuery<TQueryResult>(BaseQuery<TQueryResult> query);
    Task PublishEvent(DomainEvent @event);
}
