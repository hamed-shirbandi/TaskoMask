using System.Collections.Generic;
using TaskoMask.Application.Core.Dtos.Operators;
using TaskoMask.Application.Core.Dtos.Roles;
using TaskoMask.Application.Core.Helpers;

namespace TaskoMask.Application.Core.ViewModels
{
    public class RoleDetailViewModel
    {
        public RoleDetailViewModel()
        {
            Operators = new List<OperatorBasicInfoDto>();
            Permissions = new Dictionary<string, IEnumerable<SelectListItem>>();
        }

        public RoleInputDto Role { get; set; }
        public IEnumerable<OperatorBasicInfoDto> Operators { get; set; }
        public Dictionary<string, IEnumerable<SelectListItem>> Permissions { get; set; }

    }
}
