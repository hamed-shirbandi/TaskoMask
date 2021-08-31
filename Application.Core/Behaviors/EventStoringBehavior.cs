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
    /// So this notification handler act as a behavior and makes it easy to store events without repeating the creation of event handler
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
            await _eventStore.SaveAsync(request);
        }




        #endregion

        #region Private Methods



        #endregion
    }
}
