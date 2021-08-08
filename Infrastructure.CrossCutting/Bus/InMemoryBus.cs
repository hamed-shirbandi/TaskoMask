using MediatR;
using System.Threading.Tasks;
using TaskoMask.Application.Core.Bus;

namespace TaskoMask.Infrastructure.CrossCutting.Bus
{
    public class InMemoryBus : IInMemoryBus
    {
        private readonly IMediator _mediator;

        public InMemoryBus(IMediator mediator)
        {
            _mediator = mediator;
        }


        public async Task<TResponse> Send<TResponse>(IRequest<TResponse> request)
        {
            return await _mediator.Send(request);
        }



        public async Task Publish<TNotification>(TNotification notification) where TNotification : INotification
        {
            await _mediator.Publish(notification);
        }
    }
}

