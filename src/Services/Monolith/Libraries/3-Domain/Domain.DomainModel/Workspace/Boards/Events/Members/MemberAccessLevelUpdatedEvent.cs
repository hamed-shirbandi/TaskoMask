using TaskoMask.Domain.Core.Events;
using TaskoMask.Domain.Share.Enums;
using TaskoMask.Domain.DomainModel.Workspace.Boards.Entities;

namespace TaskoMask.Domain.DomainModel.Workspace.Boards.Events.Members
{
    public class MemberAccessLevelUpdatedEvent : DomainEvent
    {
        public MemberAccessLevelUpdatedEvent(string id, BoardMemberAccessLevel accessLevel) : base(entityId: id, entityType: nameof(Member))
        {
            Id = id;
            AccessLevel = accessLevel;
        }

        public string Id { get; }
        public BoardMemberAccessLevel AccessLevel { get;  }
    }
}
