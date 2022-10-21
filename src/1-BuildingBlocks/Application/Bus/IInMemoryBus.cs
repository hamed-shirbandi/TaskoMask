using System.Threading.Tasks;
using TaskoMask.BuildingBlocks.Application.Commands;
using TaskoMask.BuildingBlocks.Application.Queries;
using TaskoMask.BuildingBlocks.Domain.Events;

namespace TaskoMask.BuildingBlocks.Application.Bus
{
    public interface IInMemoryBus
    {
        Task<TCommandResult> SendCommand<TCommandResult>(InternalCommand<TCommandResult> command);
        Task<TQueryResult> SendQuery<TQueryResult>(BaseQuery<TQueryResult> query);
        Task PublishEvent(DomainEvent @event);
    }
}
