

using TaskoMask.Domain.Core.Enums;

namespace TaskoMask.Application.Core.Dtos.Cards
{
    public class CardInput
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public CardType Type { get; set; }
        public string BoardId { get; set; }
    }
}
