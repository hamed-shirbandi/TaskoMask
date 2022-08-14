using System.Collections.Generic;
using TaskoMask.BuildingBlocks.Contracts.Dtos.Workspace.Boards;

namespace TaskoMask.BuildingBlocks.Contracts.ViewModels
{
   public class BoardDetailsViewModel
    {
        public BoardDetailsViewModel()
        {
            Cards = new List<CardDetailsViewModel>();
        }
        public BoardOutputDto Board { get; set; }
        public IEnumerable<CardDetailsViewModel> Cards { get; set; }
    }
}
