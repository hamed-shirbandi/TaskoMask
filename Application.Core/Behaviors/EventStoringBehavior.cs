using MediatR;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TaskoMask.Application.Core.Commands;
using TaskoMask.Domain.Core.Events;
using TaskoMask.Infrastructure.Data.EventSourcing;

namespace TaskoMask.Application.Core.Behaviors
{

    /// <summary>
    /// Store each event changes to event store
    /// Each event must have at least one handler to save it in event store
    /// So this behavior makes it easy to do without repeating the creation of event handler
    /// </summary>
    public class EventStoringBehavior : INotificationHandler<IDomainEvent>
    {
        #region Fields

        private readonly IEventStore _eventStore;

        #endregion

        #region Ctors


        public EventStoringBehavior(IEventStore eventStore)
        {
            _eventStore = eventStore;
        }


        #endregion

        #region Public Methods


        /// <summary>
        /// 
        /// </summary>
        public async Task Handle(IDomainEvent request, CancellationToken cancellationToken)
        {
            var @event = new StoredEvent(entityId: "612e4a2dc47955a7738f9205", entityType: request.EntityType, eventType: request.GetType().Name, userId: "USERIDGETFROMCURRENTCONTEXT", data: request);
            await _eventStore.SaveAsync(@event);
        }




        #endregion

        #region Private Methods



        #endregion
    }
}
