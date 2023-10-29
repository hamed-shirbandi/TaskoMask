using System.Collections.Generic;
using TaskoMask.BuildingBlocks.Contracts.Dtos.Organizations;
using TaskoMask.BuildingBlocks.Contracts.Dtos.Owners;

namespace TaskoMask.BuildingBlocks.Contracts.ViewModels;

public class OwnerDetailsViewModel
{
    public OwnerDetailsViewModel() { }

    public GetOwnerDto Owner { get; set; }
    public IEnumerable<GetOrganizationDto> Organizations { get; set; }
}
