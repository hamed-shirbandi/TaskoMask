using System.Collections.Generic;
using TaskoMask.BuildingBlocks.Contracts.Dtos.Boards;

namespace TaskoMask.BuildingBlocks.Contracts.ViewModels
{
   public class BoardDetailsViewModel
    {
        public BoardDetailsViewModel()
        {
            Cards = new List<CardDetailsViewModel>();
        }
        public GetBoardDto Board { get; set; }
        public IEnumerable<CardDetailsViewModel> Cards { get; set; }
    }
}
