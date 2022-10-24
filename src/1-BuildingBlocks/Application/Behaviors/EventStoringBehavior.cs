using MediatR;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TaskoMask.BuildingBlocks.Application.Commands;
using TaskoMask.BuildingBlocks.Domain.Models;
using TaskoMask.BuildingBlocks.Domain.Services;

namespace TaskoMask.BuildingBlocks.Application.Behaviors
{

    /// <summary>
    /// Each command must have at least one event to save changes in event store
    /// So this notification handler act as a behavior and makes it easy to store events without repeating the creation of event handler
    /// However events can have another handlers to do another things like sending an email or update some other entities
    /// </summary>
    public class EventStoringBehavior : INotificationHandler<DomainEvent>
    {
        #region Fields

        private readonly IEventStoreService _eventStore;

        #endregion

        #region Ctors


        public EventStoringBehavior(IEventStoreService eventStore)
        {
            _eventStore = eventStore;
        }


        #endregion

        #region Public Methods


        /// <summary>
        /// 
        /// </summary>
        public async Task Handle(DomainEvent request, CancellationToken cancellationToken)
        {
            await _eventStore.SaveAsync(request);
        }




        #endregion

        #region Private Methods



        #endregion
    }
}
