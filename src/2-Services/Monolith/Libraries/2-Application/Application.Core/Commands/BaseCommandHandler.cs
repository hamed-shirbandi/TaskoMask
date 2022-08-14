using TaskoMask.Services.Monolith.Application.Core.Notifications;
using TaskoMask.Services.Monolith.Domain.Core.Models;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using TaskoMask.Services.Monolith.Domain.Core.Events;
using TaskoMask.Services.Monolith.Application.Core.Bus;

namespace TaskoMask.Services.Monolith.Application.Core.Commands
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class BaseCommandHandler
    {
        #region Fields


        private readonly IInMemoryBus _inMemoryBus;


        #endregion

        #region Ctors


        protected BaseCommandHandler(IInMemoryBus inMemoryBus)
        {
            _inMemoryBus = inMemoryBus;
        }


        #endregion

        #region Protected Methods



        /// <summary>
        /// publish domain events
        /// </summary>
        protected async Task PublishDomainEventsAsync(IReadOnlyCollection<IDomainEvent> domainEvents)
        {
            foreach (var domainEvent in domainEvents)
                await _inMemoryBus.Publish(domainEvent);
        }


        #endregion

        #region Private Methods






        #endregion
    }
}