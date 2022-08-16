using TaskoMask.BuildingBlocks.Contracts.Dtos.Workspace.Owners;
using TaskoMask.BuildingBlocks.Contracts.Dtos.Workspace.Organizations;
using System.Collections.Generic;

namespace TaskoMask.BuildingBlocks.Contracts.ViewModels
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
