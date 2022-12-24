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

        public GetOwnerDto Owner { get; set; }
        public IEnumerable<GetOrganizationDto> Organizations { get; set; }

    }
}
