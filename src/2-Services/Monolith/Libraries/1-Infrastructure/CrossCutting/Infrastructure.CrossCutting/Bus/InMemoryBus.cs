using MediatR;
using System.Threading.Tasks;
using TaskoMask.BuildingBlocks.Application.Bus;

namespace TaskoMask.Services.Monolith.Infrastructure.CrossCutting.Bus
{
    /// <summary>
    /// 
    /// </summary>
    public class InMemoryBus : IInMemoryBus
    {
        #region Fields
       
        private readonly IMediator _mediator;

        #endregion

        #region Ctors

        public InMemoryBus(IMediator mediator)
        {
            _mediator = mediator;
        }


        #endregion

        #region Public Methods



        /// <summary>
        /// 
        /// </summary>
        public async Task<TResponse> Send<TResponse>(IRequest<TResponse> request)
        {
            return await _mediator.Send(request);
        }



        /// <summary>
        /// 
        /// </summary>
        public async Task Publish<TNotification>(TNotification notification) where TNotification : INotification
        {
            await _mediator.Publish(notification);
        }


        #endregion

        #region Private Methods



        #endregion
    }
}

