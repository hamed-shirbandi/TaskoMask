using TaskoMask.Application.Share.Dtos.Workspace.Boards;

namespace TaskoMask.Application.Share.ViewModels
{
   public class BoardDetailsViewModel
    {
        public BoardOutputDto Board { get; set; }
        public IEnumerable<CardDetailsViewModel> Cards { get; set; }
    }
}
