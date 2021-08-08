using MediatR;
using System.Threading.Tasks;

namespace TaskoMask.Application.Core.Bus
{
    public interface IInMemoryBus
    {
        Task<TResponse> Send<TResponse>(IRequest<TResponse> request);

        Task Publish<TNotification>(TNotification notification) where TNotification : INotification;
    }
}
