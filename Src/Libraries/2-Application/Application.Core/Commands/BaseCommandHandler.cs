using TaskoMask.Application.Core.Notifications;
using TaskoMask.Domain.Core.Models;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using TaskoMask.Domain.Core.Events;
using TaskoMask.Application.Core.Bus;

namespace TaskoMask.Application.Core.Commands
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class BaseCommandHandler
    {
        #region Fields


        private readonly IDomainNotificationHandler _notifications;
        private readonly IInMemoryBus _inMemoryBus;


        #endregion

        #region Ctors


        protected BaseCommandHandler(IDomainNotificationHandler notifications, IInMemoryBus inMemoryBus)
        {
            _notifications = notifications;
            _inMemoryBus = inMemoryBus;
        }


        #endregion

        #region Protected Methods


        /// <summary>
        /// add error to notifications
        /// </summary>
        protected void NotifyValidationError(BaseCommand request, string error)
        {
            _notifications.Add(request.GetType().Name, error);
        }





        /// <summary>
        /// add domain validation errors to notifications
        /// </summary>
        protected bool IsValid(BaseEntity entity)
        {
            if (!entity.ValidationErrors.Any())
                return true;

            _notifications.AddRange(entity.ValidationErrors.ToList());
            return false;
        }



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