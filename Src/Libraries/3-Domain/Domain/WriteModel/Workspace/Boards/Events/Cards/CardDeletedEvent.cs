using TaskoMask.Domain.Core.Events;
using TaskoMask.Domain.Workspace.Boards.Entities;

namespace TaskoMask.Domain.Workspace.Boards.Events.Cards
{
    public class CardDeletedEvent : DomainEvent
    {
        public CardDeletedEvent(string id) : base(entityId: id, entityType: nameof(Card))
        {
            Id = id;
        }


        public string Id { get; }
    }
}
