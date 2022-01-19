using System.Collections.Generic;
using TaskoMask.Application.Share.Dtos.Membership.Operators;
using TaskoMask.Application.Share.Dtos.Membership.Roles;
using TaskoMask.Application.Share.Helpers;

namespace TaskoMask.Application.Share.ViewModels
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
