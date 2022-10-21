using System.Threading.Tasks;
using TaskoMask.BuildingBlocks.Domain.Events;

namespace TaskoMask.BuildingBlocks.Application.Bus
{
    /// <summary>
    /// It is used as a message broker to enable microservices communicating each other
    /// </summary>
    public interface IMessageBus
    {
        Task Publish(DomainEvent @event);
    }
}
