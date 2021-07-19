

using TaskoMask.Domain.Core.Enums;

namespace TaskoMask.Application.Services.Cards.Dto
{
    public class CardOutput
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public CardType Type { get; set; }

        public string BoardId { get; set; }
        public string CreateDateTime { get; set; }
    }
}
