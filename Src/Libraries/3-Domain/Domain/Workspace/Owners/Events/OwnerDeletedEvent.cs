﻿using TaskoMask.Domain.Core.Events;
using TaskoMask.Domain.Workspace.Owners.Entities;

namespace TaskoMask.Domain.Workspace.Owners.Events
{
    public class OwnerDeletedEvent : DomainEvent
    {
        public OwnerDeletedEvent(string id) : base(entityId: id, entityType: nameof(Owner))
        {
            Id = id;
        }


        public string Id { get; }
    }
}
