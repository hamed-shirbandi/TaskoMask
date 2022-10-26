using MassTransit;
using TaskoMask.BuildingBlocks.Application.Bus;
using TaskoMask.BuildingBlocks.Application.Commands;
using TaskoMask.BuildingBlocks.Application.Notifications;
using TaskoMask.BuildingBlocks.Application.Queries;
using TaskoMask.BuildingBlocks.Contracts.Helpers;
using TaskoMask.BuildingBlocks.Domain.Models;

namespace TaskoMask.BuildingBlocks.Web.MVC.Consumers
{
    public abstract class BaseConsumer<TMessage> : IConsumer<TMessage> where TMessage : DomainEvent
    {

        #region Fields

        private readonly IInMemoryBus _inMemoryBus;
        private readonly INotificationHandler _notifications;
        protected readonly IMessageBus _messageBus;

        #endregion

        #region Ctors



        public BaseConsumer(IInMemoryBus inMemoryBus, INotificationHandler notifications, IMessageBus messageBus)
        {
            _inMemoryBus = inMemoryBus;
            _notifications = notifications;
            _messageBus = messageBus;
        }


        #endregion

        #region Public Methods



        /// <summary>
        /// 
        /// </summary>

        public abstract Task ConsumeMessage(ConsumeContext<TMessage> context);



        /// <summary>
        /// 
        /// </summary>
        public async Task Consume(ConsumeContext<TMessage> context)
        {
            await ConsumeMessage(context);
        }


        #endregion

        #region Protected Methods





        /// <summary>
        /// 
        /// </summary>
        protected async Task<Result<CommandResult>> SendCommandAsync<TCommand>(TCommand cmd) where TCommand : BaseCommand
        {
            var result = await _inMemoryBus.SendCommand(cmd);

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
        protected async Task<Result<TQuery>> SendQueryAsync<TQuery>(BaseQuery<TQuery> query)
        {
            var result = await _inMemoryBus.SendQuery(query);
            if (_notifications.HasAny())
                return Result.Failure<TQuery>(_notifications.GetErrors());

            return Result.Success(result);
        }



        #endregion


        #region Private Methods


        #endregion
    }
}
