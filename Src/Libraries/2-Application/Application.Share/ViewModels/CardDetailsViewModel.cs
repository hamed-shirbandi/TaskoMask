using System.Collections.Generic;
using TaskoMask.Application.Share.Dtos.Workspace.Boards;
using TaskoMask.Application.Share.Dtos.Workspace.Cards;
using TaskoMask.Application.Share.Dtos.Workspace.Organizations;
using TaskoMask.Application.Share.Dtos.Workspace.Projects;
using TaskoMask.Application.Share.Dtos.Workspace.Tasks;

namespace TaskoMask.Application.Share.ViewModels
{
   public class CardDetailsViewModel
    {
        public CardBasicInfoDto Card { get; set; }
        public IEnumerable<TaskBasicInfoDto> Tasks { get; set; }
    }
}
