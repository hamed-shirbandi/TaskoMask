using System.Collections.Generic;
using TaskoMask.Application.Core.Dtos.Operators;
using TaskoMask.Application.Core.Dtos.Roles;

namespace TaskoMask.Application.Core.ViewModels
{
    public class OperatorDetailViewModel
    {
        public OperatorDetailViewModel()
        {
            Roles = new List<RoleBasicInfoDto>();
        }

        public OperatorBasicInfoDto Operator { get; set; }
        public IEnumerable<RoleBasicInfoDto> Roles { get; set; }
    }
}
