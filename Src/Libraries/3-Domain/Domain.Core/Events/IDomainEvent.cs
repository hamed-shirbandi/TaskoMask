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
        public DateTime OccurredOn { get; }
    }
}
