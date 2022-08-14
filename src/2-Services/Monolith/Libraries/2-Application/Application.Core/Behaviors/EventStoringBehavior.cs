using MediatR;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TaskoMask.Services.Monolith.Application.Core.Commands;
using TaskoMask.Services.Monolith.Domain.Core.Events;

namespace TaskoMask.Services.Monolith.Application.Core.Behaviors
{

    /// <summary>
    /// Each command must have at least one event to save changes in event store
    /// So this notification handler act as a behavior and makes it easy to store events without repeating the creation of event handler
    /// However events can have another handlers to do another things like sending an email or update some other entities
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
