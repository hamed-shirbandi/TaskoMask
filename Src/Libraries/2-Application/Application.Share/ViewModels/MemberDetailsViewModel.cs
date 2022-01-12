using TaskoMask.Application.Share.Dtos.Workspace.Members;
using TaskoMask.Application.Share.Dtos.Workspace.Organizations;

namespace TaskoMask.Application.Share.ViewModels
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
