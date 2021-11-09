using System.Collections.Generic;
using TaskoMask.Application.Core.Dtos.Administration.Operators;
using TaskoMask.Application.Core.Dtos.Administration.Roles;
using TaskoMask.Application.Core.Helpers;

namespace TaskoMask.Application.Core.ViewModels
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
