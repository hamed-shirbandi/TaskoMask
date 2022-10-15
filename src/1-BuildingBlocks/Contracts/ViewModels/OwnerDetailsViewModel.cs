using TaskoMask.BuildingBlocks.Contracts.Dtos.Owners;
using TaskoMask.BuildingBlocks.Contracts.Dtos.Organizations;
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
