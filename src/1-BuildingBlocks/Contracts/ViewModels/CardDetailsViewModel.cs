using System.Collections.Generic;
using TaskoMask.BuildingBlocks.Contracts.Dtos.Cards;
using TaskoMask.BuildingBlocks.Contracts.Dtos.Tasks;

namespace TaskoMask.BuildingBlocks.Contracts.ViewModels
{
   public class CardDetailsViewModel
    {
        public GetCardDto Card { get; set; }
        public IEnumerable<GetTaskDto> Tasks { get; set; }
    }
}
