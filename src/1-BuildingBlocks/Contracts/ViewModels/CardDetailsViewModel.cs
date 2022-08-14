using System.Collections.Generic;
using TaskoMask.BuildingBlocks.Contracts.Dtos.Workspace.Cards;
using TaskoMask.BuildingBlocks.Contracts.Dtos.Workspace.Tasks;

namespace TaskoMask.BuildingBlocks.Contracts.ViewModels
{
   public class CardDetailsViewModel
    {
        public CardBasicInfoDto Card { get; set; }
        public IEnumerable<TaskBasicInfoDto> Tasks { get; set; }
    }
}
