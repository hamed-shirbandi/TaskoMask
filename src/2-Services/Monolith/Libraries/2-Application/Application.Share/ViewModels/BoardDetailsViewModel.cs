using TaskoMask.Services.Monolith.Application.Share.Dtos.Workspace.Boards;

namespace TaskoMask.Services.Monolith.Application.Share.ViewModels
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
