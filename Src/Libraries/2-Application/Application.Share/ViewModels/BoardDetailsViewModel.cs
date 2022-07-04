using System.Collections.Generic;
using TaskoMask.Application.Share.Dtos.Workspace.Boards;
using TaskoMask.Application.Share.Dtos.Workspace.Cards;
using TaskoMask.Application.Share.Dtos.Workspace.Organizations;
using TaskoMask.Application.Share.Dtos.Workspace.Projects;

namespace TaskoMask.Application.Share.ViewModels
{
   public class BoardDetailsViewModel
    {
        public BoardOutputDto Board { get; set; }
        public IEnumerable<CardDetailsViewModel> Cards { get; set; }
    }
}
