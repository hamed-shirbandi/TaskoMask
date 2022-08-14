using TaskoMask.Services.Monolith.Application.Share.Dtos.Workspace.Owners;
using TaskoMask.Services.Monolith.Application.Share.Dtos.Workspace.Organizations;

namespace TaskoMask.Services.Monolith.Application.Share.ViewModels
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
