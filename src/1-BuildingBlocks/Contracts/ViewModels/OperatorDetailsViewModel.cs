using System.Collections.Generic;
using TaskoMask.BuildingBlocks.Contracts.Models;
using TaskoMask.BuildingBlocks.Contracts.Dtos.Membership.Operators;
using TaskoMask.BuildingBlocks.Contracts.Helpers;

namespace TaskoMask.BuildingBlocks.Contracts.ViewModels
{
    public class OperatorDetailsViewModel
    {
        public OperatorDetailsViewModel()
        {
            Roles = new List<SelectListItem>();
        }

        public OperatorBasicInfoDto Operator { get; set; }
        public IEnumerable<SelectListItem> Roles { get; set; }
    }
}
