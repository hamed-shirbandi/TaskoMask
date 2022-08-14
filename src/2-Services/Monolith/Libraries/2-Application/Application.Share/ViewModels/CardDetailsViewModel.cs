using TaskoMask.Services.Monolith.Application.Share.Dtos.Workspace.Cards;
using TaskoMask.Services.Monolith.Application.Share.Dtos.Workspace.Tasks;

namespace TaskoMask.Services.Monolith.Application.Share.ViewModels
{
   public class CardDetailsViewModel
    {
        public CardBasicInfoDto Card { get; set; }
        public IEnumerable<TaskBasicInfoDto> Tasks { get; set; }
    }
}
