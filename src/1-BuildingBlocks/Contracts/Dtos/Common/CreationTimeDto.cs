using System;
using System.ComponentModel.DataAnnotations;
using TaskoMask.BuildingBlocks.Contracts.Resources;

namespace TaskoMask.BuildingBlocks.Contracts.Dtos.Common;

public class CreationTimeDto
{
    [Display(Name = nameof(ContractsMetadata.CreateDateTime), ResourceType = typeof(ContractsMetadata))]
    public DateTime CreateDateTime { get; set; }

    [Display(Name = nameof(ContractsMetadata.CreateDateTime), ResourceType = typeof(ContractsMetadata))]
    public string CreateDateTimeString { get; set; }

    [Display(Name = nameof(ContractsMetadata.ModifiedDateTime), ResourceType = typeof(ContractsMetadata))]
    public DateTime ModifiedDateTime { get; set; }

    [Display(Name = nameof(ContractsMetadata.ModifiedDateTime), ResourceType = typeof(ContractsMetadata))]
    public string ModifiedDateTimeString { get; set; }

    [Display(Name = nameof(ContractsMetadata.CreateDay), ResourceType = typeof(ContractsMetadata))]
    public int CreateDay { get; set; }

    [Display(Name = nameof(ContractsMetadata.CreateMonth), ResourceType = typeof(ContractsMetadata))]
    public int CreateMonth { get; set; }

    [Display(Name = nameof(ContractsMetadata.CreateYear), ResourceType = typeof(ContractsMetadata))]
    public int CreateYear { get; set; }
}
