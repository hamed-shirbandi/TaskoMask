using TaskoMask.BuildingBlocks.Domain.Events;
using TaskoMask.BuildingBlocks.Contracts.Enums;
using TaskoMask.Services.Monolith.Domain.DomainModel.Workspace.Boards.Entities;

namespace TaskoMask.Services.Monolith.Domain.DomainModel.Workspace.Boards.Events.Members
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
