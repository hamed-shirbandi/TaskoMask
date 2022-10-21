using System.Threading.Tasks;
using TaskoMask.BuildingBlocks.Domain.Events;

namespace TaskoMask.BuildingBlocks.Application.Bus
{
    public interface IMessageBus
    {
        Task Publish(DomainEvent @event);
    }
}
