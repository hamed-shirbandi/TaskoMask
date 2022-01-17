using TaskoMask.Application.Share.Dtos.Workspace.Owners;
using TaskoMask.Application.Share.Dtos.Workspace.Organizations;

namespace TaskoMask.Application.Share.ViewModels
{
    public class OwnerDetailsViewModel
    {
        public OwnerDetailsViewModel()
        {

        }

        public OwnerBasicInfoDto Owner { get; set; }
        public IEnumerable<OrganizationBasicInfoDto> Organizations { get; set; }

    }
}
