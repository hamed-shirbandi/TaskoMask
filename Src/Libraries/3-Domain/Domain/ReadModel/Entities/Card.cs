using TaskoMask.Domain.Share.Enums;
using TaskoMask.Domain.Core.Models;

namespace TaskoMask.Domain.ReadModel.Entities
{
    public class Card : BaseEntity
    {
        public string Name { get; set; }
        public BoardCardType Type { get; set; }
        public string BoardId { get; set; }
    }
}
