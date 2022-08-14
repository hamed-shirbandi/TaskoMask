using MediatR;
using System.Threading.Tasks;

namespace TaskoMask.BuildingBlocks.Application.Bus
{
    public interface IInMemoryBus
    {
        Task<TResponse> Send<TResponse>(IRequest<TResponse> request);
        Task Publish<TNotification>(TNotification notification) where TNotification : INotification;
    }
}
