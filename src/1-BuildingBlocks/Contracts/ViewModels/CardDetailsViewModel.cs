using System.Collections.Generic;
using TaskoMask.BuildingBlocks.Contracts.Dtos.Cards;
using TaskoMask.BuildingBlocks.Contracts.Dtos.Tasks;

namespace TaskoMask.BuildingBlocks.Contracts.ViewModels
{
   public class CardDetailsViewModel
    {
        public CardBasicInfoDto Card { get; set; }
        public IEnumerable<TaskBasicInfoDto> Tasks { get; set; }
    }
}
