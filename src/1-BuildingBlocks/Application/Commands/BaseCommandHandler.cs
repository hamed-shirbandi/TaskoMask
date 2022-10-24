using System.Threading.Tasks;
using System.Collections.Generic;
using TaskoMask.BuildingBlocks.Application.Bus;
using TaskoMask.BuildingBlocks.Domain.Models;

namespace TaskoMask.BuildingBlocks.Application.Commands
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class BaseCommandHandler
    {
        #region Fields


        private readonly IMessageBus _messageBus;


        #endregion

        #region Ctors


        protected BaseCommandHandler(IMessageBus messageBus)
        {
            _messageBus = messageBus;
        }


        #endregion

        #region Protected Methods



        /// <summary>
        /// publish domain events
        /// </summary>
        protected async Task PublishDomainEventsAsync(IReadOnlyCollection<DomainEvent> domainEvents)
        {
            foreach (var domainEvent in domainEvents)
                await _messageBus.Publish(domainEvent);
        }


        #endregion

        #region Private Methods






        #endregion
    }
}