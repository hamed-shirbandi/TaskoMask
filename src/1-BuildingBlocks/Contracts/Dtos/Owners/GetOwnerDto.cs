using System.ComponentModel.DataAnnotations;
using TaskoMask.BuildingBlocks.Contracts.Dtos.Common;
using TaskoMask.BuildingBlocks.Contracts.Resources;

namespace TaskoMask.BuildingBlocks.Contracts.Dtos.Owners;

public class GetOwnerDto
{
    public string Id { get; set; }

    public CreationTimeDto CreationTime { get; set; }

    [Display(Name = nameof(ContractsMetadata.DisplayName), ResourceType = typeof(ContractsMetadata))]
    public string DisplayName { get; set; }

    [Display(Name = nameof(ContractsMetadata.Email), ResourceType = typeof(ContractsMetadata))]
    public string Email { get; set; }
}
