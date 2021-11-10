using System.Collections.Generic;
using TaskoMask.Application.Core.Dtos.Administration.Operators;
using TaskoMask.Application.Core.Dtos.Team.Members;
using TaskoMask.Application.Core.Dtos.Team.Organizations;
using TaskoMask.Application.Core.Helpers;

namespace TaskoMask.Application.Core.ViewModels
{
    public class MemberDetailsViewModel
    {
        public MemberDetailsViewModel()
        {

        }

        public MemberBasicInfoDto Member { get; set; }
        public IEnumerable<OrganizationBasicInfoDto> Organizations { get; set; }

    }
}
