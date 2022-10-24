using MediatR;
using System.Threading.Tasks;
using TaskoMask.BuildingBlocks.Application.Bus;
using TaskoMask.BuildingBlocks.Application.Commands;
using TaskoMask.BuildingBlocks.Application.Queries;
using TaskoMask.BuildingBlocks.Domain.Models;

namespace TaskoMask.BuildingBlocks.Infrastructure.Bus
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
        public async Task<TCommandResult> SendCommand<TCommandResult>(InternalCommand<TCommandResult> command)
        {
            return await _mediator.Send(command);
        }



        /// <summary>
        /// 
        /// </summary>
        public async Task<TQueryResult> SendQuery<TQueryResult>(BaseQuery<TQueryResult> query)
        {
            return await _mediator.Send(query);
        }



        /// <summary>
        /// 
        /// </summary>
        public async Task PublishEvent(DomainEvent @event)
        {
            await _mediator.Publish(@event);
        }


        #endregion

        #region Private Methods



        #endregion
    }
}

