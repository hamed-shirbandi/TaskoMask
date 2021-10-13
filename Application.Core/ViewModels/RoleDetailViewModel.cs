using System.Collections.Generic;
using TaskoMask.Application.Core.Dtos.Operators;
using TaskoMask.Application.Core.Dtos.Roles;

namespace TaskoMask.Application.Core.ViewModels
{
    public class RoleDetailViewModel
    {
        public RoleDetailViewModel()
        {
            Operators = new List<OperatorBasicInfoDto>();
        }

        public RoleBasicInfoDto Role { get; set; }
        public IEnumerable<OperatorBasicInfoDto> Operators { get; set; }
    }
}
