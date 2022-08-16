using System.Collections.Generic;
using TaskoMask.BuildingBlocks.Contracts.Models;
using TaskoMask.BuildingBlocks.Contracts.Dtos.Membership.Operators;
using TaskoMask.BuildingBlocks.Contracts.Dtos.Membership.Roles;
using TaskoMask.BuildingBlocks.Contracts.Helpers;

namespace TaskoMask.BuildingBlocks.Contracts.ViewModels
{
    public class RoleDetailsViewModel
    {
        public RoleDetailsViewModel()
        {
            Operators = new List<OperatorBasicInfoDto>();
            Permissions = new Dictionary<string, IEnumerable<SelectListItem>>();
        }

        public RoleUpsertDto Role { get; set; }
        public IEnumerable<OperatorBasicInfoDto> Operators { get; set; }
        public Dictionary<string, IEnumerable<SelectListItem>> Permissions { get; set; }

    }
}
