using TaskoMask.Domain.Core.Events;

namespace TaskoMask.Domain.Workspace.Boards.Events.Cards
{
    public class CardCreatedEvent : DomainEvent
    {
        public CardCreatedEvent(string id, string name, string description, string boardId) : base(entityId: id, entityType: nameof(Card))
        {
            Id = id;
            Name = name;
            Description = description;
            BoardId = boardId;
        }

        public string Id { get; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public string BoardId { get; private set; }
    }
}
