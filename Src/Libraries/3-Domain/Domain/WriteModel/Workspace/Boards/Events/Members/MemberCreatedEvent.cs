using TaskoMask.Domain.Core.Events;
using TaskoMask.Domain.Share.Enums;
using TaskoMask.Domain.Workspace.Boards.Entities;

namespace TaskoMask.Domain.Workspace.Boards.Events.Members
{
    public class MemberCreatedEvent : DomainEvent
    {
        public MemberCreatedEvent(string id, string memberOwnerId, BoardMemberAccessLevel accessLevel, string boardId) : base(entityId: id, entityType: nameof(Card))
        {
            Id = id;
            MemberOwnerId = memberOwnerId;
            AccessLevel = accessLevel;
            BoardId = boardId;
        }

        public string Id { get; }
        public string MemberOwnerId { get; private set; }
        public BoardMemberAccessLevel AccessLevel { get; private set; }
        public string BoardId { get; private set; }
    }
}
