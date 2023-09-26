using System.Threading.Tasks;
using TaskoMask.BuildingBlocks.Contracts.Events;


namespace TaskoMask.BuildingBlocks.Application.Bus
{
    /// <summary>
    /// It is used as a message broker to enable microservices communicating each other (out-process)
    /// </summary>
    public interface IMessageBus
    {
        Task Publish<TEvent>(TEvent @event) where TEvent: IntegrationEvent;
    }
}
