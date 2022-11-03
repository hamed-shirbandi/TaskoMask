using MediatR;
using System.Threading.Tasks;
using TaskoMask.BuildingBlocks.Application.Bus;
using TaskoMask.BuildingBlocks.Application.Commands;
using TaskoMask.BuildingBlocks.Application.Notifications;
using TaskoMask.BuildingBlocks.Application.Queries;
using TaskoMask.BuildingBlocks.Contracts.Helpers;
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
        private readonly INotificationHandler _notifications;

        #endregion

        #region Ctors

        public InMemoryBus(IMediator mediator, INotificationHandler notifications)
        {
            _mediator = mediator;
            _notifications = notifications;
        }


        #endregion

        #region Public Methods






        /// <summary>
        /// 
        /// </summary>
        public async Task<Result<CommandResult>> SendCommand<TCommand>(TCommand cmd) where TCommand : BaseCommand
        {
            var result = await _mediator.Send(cmd);

            //get notification errors
            var errors = _notifications.GetErrors();

            //result is null when throw application or domain exception 
            if (result == null)
                return Result.Failure<CommandResult>(errors);

            //if there is any notification error so result is failed
            if (errors.Count > 0)
                return Result.Failure<CommandResult>(errors, result.Message);

            return Result.Success(result, result.Message);
        }




        /// <summary>
        /// 
        /// </summary>
        public async Task<Result<TQueryResult>> SendQuery<TQueryResult>(BaseQuery<TQueryResult> query)
        {
            var result = await _mediator.Send(query);
            if (_notifications.HasAny())
                return Result.Failure<TQueryResult>(_notifications.GetErrors());

            return Result.Success(result);
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

