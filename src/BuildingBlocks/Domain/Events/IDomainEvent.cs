using MediatR;
using System;

namespace TaskoMask.Domain.Core.Events
{

    /// <summary>
    /// 
    /// </summary>
    public interface IDomainEvent :INotification
    {
        public string EntityId { get; }
        public string EntityType { get; }
        public string EventType { get; }
        public DateTime OccurredOn { get; }
    }
}
